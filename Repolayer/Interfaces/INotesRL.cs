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
        public Notes UpdateNotes(long notesId, long Id ,UpdateNotes updateNotes);
        public bool DeleteNotes(long id, long notesId);
        public bool IsTrash(long notesId);
        public bool ArchiveORNot(long notesId);
        public IEnumerable<Notes> GetAllArchieve(long Id);
        public IEnumerable<Notes> GetAllTrash(long Id);
        public bool DeleteTrash(long notesId);
    }
}
