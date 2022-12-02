using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeLessons.Entity
{
    public  class BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string Locations { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
