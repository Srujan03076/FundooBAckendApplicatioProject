using Bussiness_Layer;
using CommonLayer;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooApplicationbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {

        private readonly INotesBL notesBL;
        public NotesController(INotesBL notesBL)
        {
            this.notesBL = notesBL;
        }
        [Authorize]
        [HttpPost("addnotes")]
        public IActionResult CreateANote(UserNotes notes)
        {
            try
            {
                long Id= Convert.ToInt32(User.Claims.FirstOrDefault(E => E.Type == "Id").Value);
                var result = this.notesBL.CreateNote(notes, Id);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "New note created successfully ", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "New note creation unsuccessful" });
                }

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }

        [Authorize]
        [HttpGet("get")]
        public IActionResult GetAllNotesData()
        {
            try
            {
                long Id = Convert.ToInt32(User.Claims.FirstOrDefault(E => E.Type == "Id").Value);
                var result = this.notesBL.GetAllNotesData(Id);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Getting all the notes ", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Getting  notes failed" });
                    }

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }

        [Authorize]
        [HttpPut("updateNotes")]
        public IActionResult UpdateNotes(long notesId, UpdateNotes updateNotes)
        {
            try
            {
              var result = notesBL.UpdateNotes(notesId,updateNotes);
                if (result != null)

                {
                    return this.Ok(new { Success = true, message = " Updation Succesful", data= result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Not Successful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        [HttpDelete]
        [Route("DeleteNote")]
        public IActionResult Deletenote(long notesid)
        {
            try
            {
                long Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = notesBL.DeleteNotes(notesid, Id);
                if (result != null)
                {
                    return Ok(new { success = true, message = "notes Deleted succesfully" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "notes does not Deleted " });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

