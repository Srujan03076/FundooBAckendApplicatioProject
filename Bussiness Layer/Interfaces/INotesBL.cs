using CommonLayer;
using Repolayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness_Layer
{
   public interface INotesBL
    {
        public UserNotes CreateNote(UserNotes notes);
        IEnumerable<Notes> GetAllNotesData(long Id);
    }
}
