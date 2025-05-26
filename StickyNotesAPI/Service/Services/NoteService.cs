using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Context;
using Model.DTO;
using Model.Model;
using Service.IServices;

namespace Service.Services
{
    public class NoteService : INoteService
    {
        private readonly AppDBContext _context;

        public NoteService(AppDBContext dbContext)
        {
            _context = dbContext;
        }

        public List<NoteDTO> GetNotes(int userId)
        {
            return _context
                .Notes.Where(n => n.UserId == userId)
                .Select(n => new NoteDTO
                {
                    Id = n.Id,
                    Text = n.Text,
                    CategoryId = n.CategoryId,
                })
                .ToList();
        }

        public ResponseDTO CreateNote(NoteDTO newNote)
        {
            bool categoryExists = _context.Categories.Any(c => c.Id == newNote.CategoryId);
            if (!categoryExists)
            {
                return new ResponseDTO { Success = false, Message = "Category not found" };
            }

            _context.Notes.Add(
                new Note
                {
                    Text = newNote.Text,
                    CategoryId = newNote.CategoryId,
                    UserId = newNote.UserId,
                }
            );

            _context.SaveChanges();

            return new ResponseDTO { Success = true, Message = "Note created successfully" };
        }

        public ResponseDTO EditNote(NoteDTO editNote)
        {
            Note? note = _context.Notes.FirstOrDefault(n => n.Id == editNote.Id);
            if (note == null)
            {
                return new ResponseDTO { Success = false, Message = "Note not found" };
            }
            bool categoryExists = _context.Categories.Any(c => c.Id == editNote.CategoryId);
            if (!categoryExists)
            {
                return new ResponseDTO { Success = false, Message = "Category not found" };
            }

            note.Text = editNote.Text;
            note.CategoryId = editNote.CategoryId;

            _context.SaveChanges();

            return new ResponseDTO { Success = true, Message = "Note updated successfully" };
        }

        public ResponseDTO DeleteNote(int id)
        {
            Note? note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (note == null)
            {
                return new ResponseDTO { Success = false, Message = "Note not found" };
            }

            _context.Notes.Remove(note);
            _context.SaveChanges();

            return new ResponseDTO { Success = true, Message = "Note deleted successfully" };
        }
    }
}
