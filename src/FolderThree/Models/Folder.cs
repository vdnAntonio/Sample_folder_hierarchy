using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FolderThree.Models
{
    /// <summary>
    /// Represents database entity
    /// </summary>
    public class Folder
    {
        /// <summary>
        /// Gets or sets the folder id
        /// </summary>
        [Key]
        public int FolderId { get; set; }

        /// <summary>
        /// Gets or sets the folder name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent folder id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets child folders
        /// </summary>
        [ForeignKey("ParentId")]
        public virtual ICollection<Folder> Childs { get; set; }

        /// <summary>
        /// Gets or sets current folder path
        /// </summary>
        [NotMapped]
        public string Path { get; set; }
    }
}
