using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;

namespace Service.IServices
{
    public interface INoteService
    {
        List<NoteDTO> GetNotes(int userId);
        ResponseDTO CreateNote(NoteDTO newNote);
        ResponseDTO EditNote(NoteDTO editNote);
        ResponseDTO DeleteNote(int id);
    }
}
