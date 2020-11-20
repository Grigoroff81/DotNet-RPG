using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetRpg.Models
{
    public class RpgClass
    {
        public int RpgClassId { get; set; }
        public string RpgClassName { get; set; }
        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
