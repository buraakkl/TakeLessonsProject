using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeLessons.Entity
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
    }
}
