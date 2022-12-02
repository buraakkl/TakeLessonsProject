using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeLessons.Entity
{
    public class StateOfEducationsLevel
    {
        public int StateOfEducationsLevelId { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public string? Url { get; set; }

    }
}
