using CommonLayer;
using CommonLayer.Model;
using Repolayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repolayer.Interfaces
{
    public interface INotesRL
    {

        public List<Notes> GetAllNotesData(long Id);
        public Notes CreateNote(UserNotes notes,long Id);
        public Notes UpdateNotes(long notesId, UpdateNotes updateNotes);
        public bool DeleteNotes(long id, long notesId);
    }
}
