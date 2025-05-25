using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;
using Model.Model;

namespace Service.IServices
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetCategory(int id);
        ResponseDTO CreateCategory(CategoryDTO newcat);
        ResponseDTO EditCategory(CategoryDTO editcat);
        ResponseDTO DeleteCategory(int id);
    }
}
