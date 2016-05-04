using System;
using System.Linq;
using System.Threading.Tasks;
using FolderThree.DbContext;
using Microsoft.AspNet.Mvc;

namespace FolderThree.api
{
    public class FolderController : Controller
    {
        /// <summary>
        /// Data from the client-side
        /// </summary>
        public class ValueModel
        {
            /// <summary>
            /// Path from the URL
            /// </summary>
            public string Path { get; set; }
        }

        /// <summary>
        /// Returns folders hierarchy
        /// </summary>
        /// <param name="model">Model with current path</param>
        /// <returns>Folder with paths</returns>
        [HttpPost, Route("/api/folder")]
        public async Task<JsonResult> FoldersAsync([FromBody]ValueModel model)
        {                
            // Split does not like when the last character is '/'
            model.Path = model.Path.Length > 0
                ? (model.Path.Last() == '/' ? model.Path.Remove(model.Path.Length - 1) : model.Path)
                : model.Path;
            
            var name = model.Path == ""
                    ? FolderRepository.Instance.GetRootFolderAsync().Result.Name
                    : model.Path.Split(new[] { "/" }, StringSplitOptions.None).Last();

            var folder = await FolderRepository.Instance.GetFolderByNameAsync(name);

            var foldersWithPath = FolderRepository.Instance.BuildPath(folder, model.Path);
            return Json(foldersWithPath);
        }
    }
}