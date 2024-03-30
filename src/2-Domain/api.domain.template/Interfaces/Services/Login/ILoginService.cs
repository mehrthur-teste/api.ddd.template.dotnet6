using api.domain.template.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.domain.template.Interfaces.Services.Login
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto user);
    }
}
