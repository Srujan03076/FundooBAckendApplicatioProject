using CommonLayer;
using Repolayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness_Layer
{
   public interface INotesBL
    {
        public Notes CreateNote(UserNotes notes, long Id);
        IEnumerable<Notes> GetAllNotesData(long Id);
        public UserNotes UpdateNotes(UserNotes usernotes);
    }
}
