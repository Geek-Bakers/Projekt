using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Projekt.ModelsDTO;
using Projekt.Services.Interfejsy;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Services.Implementacje
{
    public class BLOBService : IBLOBService
    {
        public async Task<ResponseDTO> UploadFileAsync(int userId, string path)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=projm;AccountKey=XmqQW6xam/JRDPeTcEodV0BhCNG+jAi6bz8VQ0aWKlrngrl0kTMWpn4VVfItuSXor1iu0aFChJSDMfIoWpGTpw==;EndpointSuffix=core.windows.net");
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CultureInfo myCI = new CultureInfo("en-US");
                Calendar myCal = myCI.Calendar;
                CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
                DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(DateTime.Now.Year.ToString());

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }

                string imageName = Path.GetFileName(path);
                var pathInBlobStorage = $"{userId}/{myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW)}/{imageName}";

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(pathInBlobStorage);
                await cloudBlockBlob.UploadFromFileAsync(path);

                return new ResponseDTO() { Code = "200", Status = "Success", Message = $"Uploaded file to blob." };
            }
            catch (Exception exception)
            {
                return new ResponseDTO() { Code = "400", Status = "Failed", Message = $"Upload file to blob failed. Error message: {exception.Message}" };
            }
        }
    }
}
