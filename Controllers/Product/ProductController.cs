using AutoMapper;
using Bar_Management_System.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repos;

namespace Bar_Management_System.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _unitOfWork.Product.GetAll(includes: new List<string> { "Category", "Supplier", "Branch" });

                if (products.Count > 0)
                {
                    var result = _mapper.Map<IList<ProductDTO>>(products);
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
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data");

                var category = await _unitOfWork.Category.Get(x => x.Id == productDTO.CategoryId);
                var supplier = await _unitOfWork.Supplier.Get(x => x.Id == productDTO.SupplierId);
                var branch = await _unitOfWork.Branch.Get(x => x.Id == productDTO.BranchId);

                if (category == null || supplier == null || branch == null)
                {
                    return BadRequest("Invalid Category, Supplier, or Branch Id");
                }

                var product = _mapper.Map<Model.ProductManagement.Product>(productDTO);

                await _unitOfWork.Product.Insert(product);
                await _unitOfWork.Save();

                return Ok(product);
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
        public async Task<IActionResult> UpdateProduct(int Id, [FromBody] ProductDTO productDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var productDetails = await _unitOfWork.Product.Get(x => x.Id == Id);

                if (productDetails == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                productDTO.Id = productDetails.Id;

                _mapper.Map(productDTO, productDetails);

                _unitOfWork.Product.Update(productDetails);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error. Please Try Again Later. {ex}");
            }
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            try
            {
                var product = await _unitOfWork.Product.Get(x => x.Id == Id);

                if (product == null)
                {
                    return NotFound($"Product with Id {Id} not found");
                }

                _unitOfWork.Product.Delete(product);
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
