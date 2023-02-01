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
    [Authorize]//for all method need token (authorization)
    public class NotesController : ControllerBase
    {

        private readonly INotesBL notesBL;
        public NotesController(INotesBL notesBL)
        {
            this.notesBL = notesBL;
        }
       
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

        [HttpGet("getnotesdata")]
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

      
        [HttpPut("updateNotes")]
        public IActionResult UpdateNotes(long notesId, UpdateNotes updateNotes)
        {
            try
            {
               long Id = Convert.ToInt32(User.Claims.FirstOrDefault(E => E.Type == "Id").Value);
                var result = notesBL.UpdateNotes(notesId,Id,updateNotes);
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
        
        [HttpDelete("deleteNote")]
        
        public IActionResult Deletenote(long notesid)
        {
            try
            {
                long Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = notesBL.DeleteNotes(notesid, Id);
                if (result == true)
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

      
        [HttpPut("trash")]
        public IActionResult IsTrash(int notesId)
        {
            try
            {
                long Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = this.notesBL.IsTrash(notesId);
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note moved to trash Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccesful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
       
        [HttpGet("getAllTrash")]
        
        public IActionResult GetAllTrash()
        {
            try
            {
                long Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);///////
                var result = this.notesBL.GetAllTrash(Id);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Trash data found", data = result });

                }
                else
                {
                    return BadRequest(new { success = false, message = "Trash data not found" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        [HttpDelete("permanentlydeletetrash")]
        public IActionResult DeleteTrashforever(long notesId)
        {
            long Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
            var result = this.notesBL.DeleteTrash(notesId);
            if (result == true)
            {
                return Ok(new { success = true, message = "Data/Message is deleted from trash" });
            }
            else
            {
                return BadRequest(new { success = false, message = "Data/Message is not deleted from trash" });

            }
        }

        
        [HttpPut("archive")]
        public IActionResult ArchiveORUnarchive(long notesId)
        {

            long Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
            var result = this.notesBL.ArchiveORNot(notesId);
            if (result == true)
            {
                return Ok(new { success = true, message = "Note is Archieved" });
            }
            else
            {
                return BadRequest(new { success = false, message = "Note is not Archieved" });

            }
        }
       
        [HttpGet]
        [Route("getAllArchive")]
        public IActionResult GetAllArchieve()
        {
            try
            {
                long Id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);///////
                var result = this.notesBL.GetAllArchieve(Id);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Get archived data", data = result });

                }
                else
                {
                    return BadRequest(new { success = false, message = "Failed to  get archived data" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

