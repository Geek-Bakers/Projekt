using Projekt.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Services.Interfejsy
{
    public interface ICosmoService
    {
        Task<ResponseDTO> Save(ResorceDTO resource);
    }
}
