using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


namespace Projektpos1.Models
{
    public class ViewModel
    {
        public string ContainerName { get; set; }
        public string StorageUri { get; set; }
        public string FileName { get; set; }
        public string PrimaryUri { get; set; }
        public string fileExtenion { get; set; }

        public string FileNameWithoutExt
        {
            get
            {
                return Path.GetFileNameWithoutExtension(FileName);
            }
        }

        public string FileNameExtensionOnly
        {
            get
            {
                return System.IO.Path.GetExtension(FileName).Substring(1);
            }
        }
    }
}