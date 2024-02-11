using AutoMapper;
using Bar_Management_System.DTO;
using Bar_Management_System.Model.SupplierManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repos;

namespace Bar_Management_System.Controllers.Suppliers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SupplierController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSuppliers()
        {
            try
            {
                var suppliers = await _unitOfWork.Supplier.GetAll(includes: new List<string> { "Branch" });

                if (suppliers.Count > 0)
                {
                    var result = _mapper.Map<IList<SupplierDTO>>(suppliers);
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
        public async Task<IActionResult> CreateSupplier([FromBody] SupplierDTO supplierDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data");

                

               

                

                var supplier = _mapper.Map<Model.SupplierManagement.Supplier>(supplierDTO);

                await _unitOfWork.Supplier.Insert(supplier);
                await _unitOfWork.Save();
                var branch = await _unitOfWork.Branch.Get(x => x.Id == supplier.BranchId);
                supplier.Branch = branch;
                return Ok(supplier) ;
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
        public async Task<IActionResult> UpdateSupplier(int Id, [FromBody] SupplierDTO supplierDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var supplierDetails = await _unitOfWork.Supplier.Get(x => x.Id == Id);

                supplierDTO.Id = supplierDetails.Id;

                if (supplierDetails == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                _mapper.Map(supplierDTO, supplierDetails);
                
                _unitOfWork.Supplier.Update(supplierDetails);
                await _unitOfWork.Save();

                var branch = await _unitOfWork.Branch.Get(x => x.Id == supplierDetails.BranchId);
                supplierDetails.Branch = branch;
                return Ok(supplierDetails);
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
        public async Task<IActionResult> DeleteSupplier(int Id)
        {
            try
            {
                var supplier = await _unitOfWork.Supplier.Get(x => x.Id == Id);

                if (supplier == null)
                {
                    return NotFound($"Supplier with Id {Id} not found");
                }

                _unitOfWork.Supplier.Delete(supplier);
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

