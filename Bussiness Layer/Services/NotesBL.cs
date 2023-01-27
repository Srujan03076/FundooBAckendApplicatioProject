using CommonLayer;
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

      

        public IEnumerable<Notes> GetAllNotesData(long Id)
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

        public UserNotes UpdateNotes(UserNotes usernotes)
        {
            try
            {
                return this.notesRL.UpdateNotes( usernotes);
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
    }
}
      
    

