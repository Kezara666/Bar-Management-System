using Data.Model.BranchManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.UserManagement
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int  Name{ get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public ICollection<Window> UserWindows { get; set; }

    }
}
