using CommonLayer;
using Repolayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repolayer.Interfaces
{
    public interface INotesRL
    {

        public IEnumerable<Notes> GetAllNotesData(long Id);
        public UserNotes UpdateNotes(UserNotes usernotes);
        public Notes CreateNote(UserNotes notes,long Id);
    }
}
