using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Service.IServices;

namespace StickyNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetCategories/{id}")]
        public ActionResult<List<CategoryDTO>> GetCategory([FromRoute] int id)
        {
            try
            {
                var response = _service.GetCategory(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateCategory")]
        public ActionResult<ResponseDTO> CreateCategory([FromBody] CategoryDTO newcat)
        {
            try
            {
                var response = _service.CreateCategory(newcat);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("EditCategory")]
        public ActionResult<ResponseDTO> EditCategory([FromBody] CategoryDTO editcat)
        {
            try
            {
                var response = _service.EditCategory(editcat);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCategory/{id}")]
        public ActionResult<ResponseDTO> DeleteCategory([FromRoute] int id)
        {
            try
            {
                var response = _service.DeleteCategory(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
