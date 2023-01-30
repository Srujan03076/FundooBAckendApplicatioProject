using CommonLayer;
using CommonLayer.Model;
using Repolayer.Entities;
using Repolayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness_Layer.Services
{
    public class NotesBL : INotesBL
    {

        private readonly INotesRL notesRL;
        public NotesBL(INotesRL notesRL)
        {
            this.notesRL = notesRL;
        }



        public List<Notes> GetAllNotesData(long Id)
        {
            try
            {
                return this.notesRL.GetAllNotesData(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Notes UpdateNotes(long notesId, UpdateNotes updateNotes)
        {
            try
            {
                return this.notesRL.UpdateNotes(notesId, updateNotes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Notes CreateNote(UserNotes notes, long Id)
        {
            try
            {
                return notesRL.CreateNote(notes,Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteNotes(long id, long notesId)
        {
            try
            {

                return notesRL.DeleteNotes(id, notesId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
      
    

