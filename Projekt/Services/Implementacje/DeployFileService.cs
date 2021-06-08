using Projekt.ModelsDTO;
using Projekt.Services.Interfejsy;
using SDBWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Services.Implementacje
{
    public class DeployFileService : IDeployFileService
    {
        private readonly SDBContext context;
        private readonly ICosmoService cosmoService;
        private readonly IBLOBService bLOBService;

        public DeployFileService(SDBContext context,
                                    ICosmoService cosmoService,
                                    IBLOBService bLOBService)
        {
            this.context = context;
            this.cosmoService = cosmoService;
            this.bLOBService = bLOBService;
        }

        public ResponseDTO UploadFile(int userId, string path)
        {
            var user = context.Users.Where(u => u.Id == userId).SingleOrDefault();

            if (user == null)
                return new ResponseDTO() { Code = "400", Status = "Failed", Message = $"Email or password is null" };

            //wysylamy do bloba
            var blobResult = bLOBService.UploadFileAsync(userId, path);

            if (blobResult.Result.Status == "Failed")
                return new ResponseDTO() { Code = "400", Status = "Failed", Message = $"Save file in Blob failed" };

            //wysylamy do cosmo
            var resource = new ResorceDTO()
            {
                SenderId = userId,
                FileName = path,//do poprawy
                SendedTime = DateTime.Now
            };

            var cosmoResult = cosmoService.Save(resource);

            if (cosmoResult.Result.Status == "Failed")
                return new ResponseDTO() { Code = "400", Status = "Failed", Message = $"Save data in DocumentDb failed" };

            return new ResponseDTO() { Code = "200", Status = "Success", Message = $"File uploded" };
        }
    }
}
