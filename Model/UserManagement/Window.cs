using System.ComponentModel.DataAnnotations;

namespace Data.Model.UserManagement
{
    public class Window
    {
        [Key]
        public int WindowId { get; set; }
        public string WindowName { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<User> Users { get; set; }
    }
}