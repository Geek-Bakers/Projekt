using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projektpos1.Models;
using Projektpos1.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Threading.Tasks;

namespace Projektpos1.Interfaces
{
    public class CloudStorage : ICloudStorage
    {
        private StorageCredentials _storageCredentialsx;
        private CloudStorageAccount _cloudStorageAccountx;
        private CloudBlobClient _cloudBlobClientx;
        private CloudBlobContainer _cloudBlobContainerx;
        private string containerNamex = "mycontainer";
        private string downloadPath = @"C:\AZ\";

        public CloudStorage()
        {
            string accountNamex = "projektpos";///////////////////////////////////////////////////////////////////
            string keyx = "we+moeZ8QMSbw3CnzOzcx3xaSSNtT6hiTptriXsrL7l7YSp0PR2/4Xd0apJmM3Y5SDv152kxjNrZMdQsMNQNow==";///////////////////////////////////////////////////////////////////////////

            _storageCredentialsx = new StorageCredentials(accountNamex, keyx);
            _cloudStorageAccountx = new CloudStorageAccount(_storageCredentialsx, true);
            _cloudBlobClientx = _cloudStorageAccountx.CreateCloudBlobClient();
            _cloudBlobContainerx = _cloudBlobClientx.GetContainerReference(containerNamex);
        }

        public bool DeleteFile(string file, string fileExtension)
        {
            _cloudBlobContainerx = _cloudBlobClientx.GetContainerReference(containerNamex);

            CloudBlockBlob blockBlob = _cloudBlobContainerx.GetBlockBlobReference(file + "." + fileExtension);
            bool deleted = blockBlob.DeleteIfExists();

            return deleted;
        }

        public async Task<bool> DownloadFileAsync(string file, string fileExtension)
        {
            _cloudBlobContainerx = _cloudBlobClientx.GetContainerReference(containerNamex);
            CloudBlockBlob blockBlob = _cloudBlobContainerx.GetBlockBlobReference(file + "." + fileExtension);


            using (var fileStream = System.IO.File.OpenWrite(downloadPath + file + "." + fileExtension))
            {
                await blockBlob.DownloadToStreamAsync(fileStream);

                return true;
            }
        }

        public IEnumerable<ViewModel> GetFiles()
        {
            var context = _cloudBlobContainerx.ListBlobs().ToList();
            IEnumerable<ViewModel> VM = context.Select(x => new ViewModel
            {
                ContainerName = x.Container.Name,
                StorageUri = x.StorageUri.PrimaryUri.ToString(),
                PrimaryUri = x.StorageUri.PrimaryUri.ToString(),
                FileName = x.Uri.AbsoluteUri.Substring(x.Uri.AbsoluteUri.LastIndexOf("/") + 1),
                fileExtenion = System.IO.Path.GetExtension(x.Uri.AbsoluteUri.Substring(x.Uri.AbsoluteUri.LastIndexOf("/") + 1))

            }).ToList();
            return VM;
        }

        public bool UploadFile(HttpPostedFileBase blobFile)
        {
            if (blobFile == null)
            {
                return false;
            }

            _cloudBlobContainerx = _cloudBlobClientx.GetContainerReference(containerNamex);
            CloudBlockBlob blockBlob = _cloudBlobContainerx.GetBlockBlobReference(blobFile.FileName);

            using (var fileStream = (blobFile.InputStream))
            {
                blockBlob.UploadFromStream(fileStream);
            }
            return true;
        }
    }
}