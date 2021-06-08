using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Projektpos1.Models;

namespace Projektpos1.Interfaces
{
    public interface ICloudStorage
    {
        IEnumerable<ViewModel> GetFiles();
        bool DeleteFile(string file, string fileExtension);
        bool UploadFile(HttpPostedFileBase blobFile);

        Task<bool> DownloadFileAsync(string file, string fileExtension);
    }
}
