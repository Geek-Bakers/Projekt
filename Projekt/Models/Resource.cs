using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// This is Resource BD Table
/// </summary>

namespace Projekt.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int NumberOfWeek { get; set; }
        public int NumberOfFile { get; set; }

        public virtual User User { get; set; }
    }
}
