using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Projekt.ModelsDTO;
using Projekt.Services.Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Controllers
{
    [Produces("application/json")]
    public class DeployFileController : Controller
    {
        private readonly IDeployFileService deployFileService;

        public DeployFileController(IDeployFileService deployFileService)
        {
            this.deployFileService = deployFileService;
        }

        [Route("api/deployFile/upload/{userId}/{path}")]
        [HttpPost]
        public ResponseDTO UploadFile(int userId, string path)
        {
            return deployFileService.UploadFile(userId, path);
        }
    }
}
