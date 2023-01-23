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

        public UserNotes CreateNote(UserNotes notes)
        {
            try
            {
                return notesRL.CreateNote(notes);
            }
            catch (Exception)
            {
                throw;
            }
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
    }
}
      
    

