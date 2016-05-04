using FolderThree.Models;
using Microsoft.Data.Entity;

namespace FolderThree.DbContext
{
    public class FolderContext : Microsoft.Data.Entity.DbContext
    {
        public DbSet<Folder> Folders { get; set; }
    }
}
