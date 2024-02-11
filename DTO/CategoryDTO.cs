using Data.Model.BranchManagement;

namespace Bar_Management_System.DTO
{
    public class CreateCategoryDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int BranchId { get; set; }

    }

    public class ShowCategoryDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

    }
}
