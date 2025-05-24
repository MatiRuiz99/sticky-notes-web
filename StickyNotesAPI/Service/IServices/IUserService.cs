using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;

namespace Service.IServices
{
    public interface IUserService
    {
        ResponseDTO Register(UserDTO user);
        ResponseDTO Login(UserDTO user);
    }
}
