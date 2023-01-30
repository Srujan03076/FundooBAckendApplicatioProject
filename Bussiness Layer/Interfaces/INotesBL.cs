using CommonLayer;
using CommonLayer.Model;
using Repolayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness_Layer
{
   public interface INotesBL
    {
        public Notes CreateNote(UserNotes notes, long Id);
        public List<Notes> GetAllNotesData(long Id);
        public Notes UpdateNotes(long notesId, UpdateNotes updateNotes);
        
        public bool DeleteNotes(long notesId, long id);
    }
}
