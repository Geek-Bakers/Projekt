using Projekt.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Services.Interfejsy
{
    public interface IBLOBService
    {
        Task<ResponseDTO> UploadFileAsync(int userId, string path);
    }
}
