using System;
using System.Linq;
using System.Threading.Tasks;
using FolderThree.Models;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace FolderThree.DbContext
{
    /// <summary>
    /// Represents folders repository
    /// </summary>
    public class FolderRepository
    {
        /// <summary>
        /// Holds folders dbset
        /// </summary>
        private DbSet<Folder> _folders;

        /// <summary>
        /// Initializes a instance of the <see cref="FolderRepository"/> class
        /// </summary>
        public static FolderRepository Instance => _instance.Value;

        private static readonly Lazy<FolderRepository> _instance = new Lazy<FolderRepository>(() => new FolderRepository());

        /// <summary>
        /// Initializes <see cref="FolderContext"/> class
        /// </summary>
        public void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<FolderContext>();
            _folders = context.Folders;
        }

        /// <summary>
        /// Returns the folder by its name
        /// </summary>
        /// <param name="name">Folder name</param>
        /// <returns>Folder</returns>
        public async Task<Folder> GetFolderByNameAsync(string name)
        {
            return await _folders.Where(f => f.Name == name).Include(f => f.Childs).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Returns the first folder in the hierarchy
        /// </summary>
        /// <returns>Folder</returns>
        public async Task<Folder> GetRootFolderAsync()
        {
            return await _folders.FirstAsync();
        }

        /// <summary>
        /// Builds the path of the current folder and its children
        /// </summary>
        /// <param name="folder">Current folder</param>
        /// <param name="path">Current path</param>
        /// <returns></returns>
        public Folder BuildPath(Folder folder, string path)
        {
            var currentPath = $"{path}/{folder.Name}";
            var currentFolder = new Folder
            {
                FolderId = folder.FolderId,
                Name = folder.Name,
                Path = currentPath,
                Childs = folder.Childs.Select(f => new Folder
                {
                    FolderId = f.FolderId,
                    Name = f.Name,
                    Path = $"{currentPath}/{f.Name}"
                }).ToArray()
            };
            return currentFolder;
        }
    }
}