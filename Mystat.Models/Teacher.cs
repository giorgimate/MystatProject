using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pin { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
