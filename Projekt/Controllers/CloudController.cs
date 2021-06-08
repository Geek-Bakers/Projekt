using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekt.Interfaces;
using System.Threading.Tasks;

namespace Projektpos1.Controllers
{
    public class CloudController : Controller
    {
        private readonly ICloudStorage repo;
        public CloudController(ICloudStorage _repo)
        {
            this.repo = _repo;
        }

        public ActionResult Index()
        {
            var blobVM = repo.GetFiles();
            return View(blobVM);
        }

        public JsonResult RemoveFile(string file, string extension)
        {
            bool isDeleted = repo.DeleteFile(file, extension);
            return Json(isDeleted, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DownloadFile(string file, string extension)
        {
            bool isDownloaded = await repo.DownloadFileAsync(file, extension);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase uploadFileName)
        {
            bool isUploaded = repo.UploadFile(uploadFileName);
            if (isUploaded == true)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
