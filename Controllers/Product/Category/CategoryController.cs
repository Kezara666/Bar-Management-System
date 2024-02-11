using AutoMapper;
using Bar_Management_System.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repos;

namespace Bar_Management_System.Controllers.Product.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _unitOfWork.Category.GetAll(includes: new List<string> { "Branch"});
                if (categories.Count > 0)
                {
                    var result = _mapper.Map<IList<ShowCategoryDTO>>(categories);
                    return Ok(result);
                }
                else
                {
                    return Ok("No Found Result");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error. Please Try Again Later. {ex}");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data");

                // Log the value of categoryDTO.BranchId
                Console.WriteLine($"categoryDTO.BranchId: {categoryDTO.BranchId}");

                // Get the Branch from category
                var branch = await _unitOfWork.Branch.Get(x => x.Id == categoryDTO.BranchId);
                var DataCategory = new ShowCategoryDTO() { Id = 0,BranchId = branch.Id,Name=categoryDTO.Name};


                var category = _mapper.Map<Model.ProductManagement.Category>(DataCategory);

                await _unitOfWork.Category.Insert(category);
                await _unitOfWork.Save();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error. Please Try Again Later. {ex}");
            }
        }


        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCategory(int Id, [FromBody] CreateCategoryDTO categoryDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var categoryDetails = await _unitOfWork.Category.Get(x => x.Id == Id);

                if (categoryDetails == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                // _mapper.Map(categoryDTO, categoryDetails);
                categoryDetails.Name = categoryDTO.Name;
                categoryDetails.BranchId=categoryDTO.BranchId;

                _unitOfWork.Category.Update(categoryDetails);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error. Please Try Again Later. {ex}");
            }
        }
    }
}
