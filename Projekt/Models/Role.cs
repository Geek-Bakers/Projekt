using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// This is Role DB table
/// </summary>

namespace Projekt.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
