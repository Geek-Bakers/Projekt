using Projekt.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Services.Interfejsy
{
    public interface IDeployFileService
    {
        ResponseDTO UploadFile(int userId, string path);
    }
}
