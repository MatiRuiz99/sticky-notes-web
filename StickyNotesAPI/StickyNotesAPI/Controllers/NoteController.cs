using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Service.IServices;

namespace StickyNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _service;

        public NoteController(INoteService service)
        {
            _service = service;
        }

        [HttpGet("GetNotes/{id}")]
        public ActionResult<List<NoteDTO>> GetNotes([FromRoute] int id)
        {
            try
            {
                var response = _service.GetNotes(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateNote")]
        public ActionResult<ResponseDTO> CreateNote([FromBody] NoteDTO newNote)
        {
            try
            {
                var response = _service.CreateNote(newNote);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("EditNote")]
        public ActionResult<ResponseDTO> EditNote([FromBody] NoteDTO editNote)
        {
            try
            {
                var response = _service.EditNote(editNote);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteNote/{id}")]
        public ActionResult<ResponseDTO> DeleteNote([FromRoute] int id)
        {
            try
            {
                var response = _service.DeleteNote(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
