using CommonLayer;
using CommonLayer.Model;
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

        public bool DeleteNotes(long id, long notesId)
        {
            try
            {
                var result = context.NoteTable.Where(e => e.Id == id && e.NotesId == notesId).FirstOrDefault();

                if (result != null)
                {
                    context.NoteTable.Remove(result);
                    context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Notes> GetAllNotesData(long Id)
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

       

        public Notes UpdateNotes(long notesId, UpdateNotes updateNotes)
        {
            try
            {
                var note = context.NoteTable.FirstOrDefault(r =>  r.NotesId == notesId);
                if (note != null)
                {
                    note.Title = updateNotes.Title;
                    note.Description = updateNotes.Description;
                    note.Color = updateNotes.Color;
                    note.Image = updateNotes.Image;
                    note.ModifiedAt = updateNotes.ModifierAt;
                    note.Id = notesId;
                    context.NoteTable.Update(note);
                    int result = context.SaveChanges();
                    return note;
                }
                else
                    return null;

            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}


















