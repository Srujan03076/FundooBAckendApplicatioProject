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
        public Notes UpdateNotes(long notesId, long Id, UpdateNotes updateNotes);
        
        public bool DeleteNotes(long notesId, long id);
        public bool IsTrash(long notesId);
        public bool ArchiveORNot(long notesId);
        public IEnumerable<Notes> GetAllArchieve(long Id);
        public IEnumerable<Notes> GetAllTrash(long Id);
        public bool DeleteTrash(long notesId);
    }
}
