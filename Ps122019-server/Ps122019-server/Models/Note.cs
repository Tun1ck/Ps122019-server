using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ps122019_server.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
