using AutoMapper;
using Bar_Management_System.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repos;
using System.Collections;
using System.Collections.Generic;


namespace Bar_Management_System.Controllers.Branch
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchersController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BranchersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBranch()
        {
            try
            {
                var Branch = await _unitOfWork.Branch.GetAll();
                if(Branch.Count>0)
                {
                    var result = _mapper.Map<IList<BranchDTO>>(Branch);
                    return Ok(result);
                }
                else
                {
                    return Ok("No Found Resault");

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
        public async Task<IActionResult> CreateBranch([FromBody] BranchDTO branchDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data");

                

                var branch = _mapper.Map<Data.Model.BranchManagement.Branch>(branchDTO);


                await _unitOfWork.Branch.Insert(branch);
                await _unitOfWork.Save();

                return Ok(branch);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error. Please Try Again Later.{ex}");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBranchById(int id)
        {
            try
            {
                var branch = await _unitOfWork.Branch.Get(x => x.Id == id);

                if (branch == null)
                {
                    return NotFound($"Branch with ID {id} not found");
                }

                var result = _mapper.Map<BranchDTO>(branch);
                return Ok(result);
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
        public async Task<IActionResult> UpdateBranch(int Id, [FromBody] BranchDTO branchDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var branchDetails = await _unitOfWork.Branch.Get(x => x.Id == Id);

                if (branchDetails == null)
                {
                    return BadRequest("submitted data is invalid");
                }

                _mapper.Map(branchDTO, branchDetails);

                _unitOfWork.Branch.Update(branchDetails);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error, Please try again later. {ex}");
            }
        }




    }
}
