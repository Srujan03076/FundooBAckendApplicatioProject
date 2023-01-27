using CommonLayer;
using Microsoft.Extensions.Configuration;
using Repolayer.Context;
using Repolayer.Entities;
using Repolayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repolayer.Services
{
    public class NotesRL : INotesRL
    {
        FundooContext context;
        IConfiguration _config;

        public NotesRL(FundooContext _context, IConfiguration _config)
        {
            this.context = _context;
            this._config = _config;
        }

        public Notes CreateNote(UserNotes notes,long Id)
        {
            try
            {
                Notes newNotes = new Notes();
                newNotes.Title = notes.Title;
                newNotes.Description = notes.Description;
                newNotes.Reminder = notes.Reminder;
                newNotes.Color = notes.Color;
                newNotes.Image = notes.Image;
                newNotes.IsTrash = notes.IsTrash;
                newNotes.IsArchive = notes.IsArchive;
                newNotes.IsPinned = notes.IsPinned;
                newNotes.CreatedAt = notes.CreatedAt;
                newNotes.ModifiedAt = notes.ModifiedAt;
                newNotes.Id = Id;
               //Adding the data to database
                this.context.NoteTable.Add(newNotes);
                //Save the changes in database
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return newNotes;
                }
                else
                {
                    return default;
                }
            }
            catch (Exception e)
            {
                throw;

            }
        }

        public IEnumerable<Notes> GetAllNotesData(long Id)
        {
            try
            {
                var result = context.NoteTable.Where(e => e.Id == Id).ToList();
                if (result != null)
                {

                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserNotes UpdateNotes(UserNotes usernotes)
        {

            var UpdateNote = this.context.NoteTable.Where(Y => Y.Id == usernotes.Id).FirstOrDefault();
            if (UpdateNote != null)
            {
                UpdateNote.Title = usernotes.Title;
                UpdateNote.Description = usernotes.Description;
                UpdateNote.Reminder = usernotes.Reminder;
                UpdateNote.Color = usernotes.Color;
                UpdateNote.Image = usernotes.Image;
                UpdateNote.IsArchive = usernotes.IsArchive;
                UpdateNote.IsPinned = usernotes.IsPinned;
                UpdateNote.IsTrash = usernotes.IsTrash;
                UpdateNote.CreatedAt = usernotes.CreatedAt;


            }
            var result = this.context.SaveChanges();
            if (result > 0)
            {
                return usernotes;
            }
            else
            {
                return default;
            }
        }
    }
}


















