using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.ModelsDTO
{
    public class ResorceDTO
    {
        public string Id { get; set; }
        public int SenderId { get; set; }
        public string FileName { get; set; }
        public DateTime SendedTime { get; set; }
    }
}
