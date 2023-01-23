using CommonLayer;
using Repolayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repolayer.Interfaces
{
    public interface INotesRL
    {
       public  UserNotes CreateNote(UserNotes notes);
        public IEnumerable<Notes> GetAllNotesData(long Id);
    }
}
