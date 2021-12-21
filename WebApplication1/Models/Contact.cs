using System;
using System.Web;

namespace WebApplication1.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
    }
}