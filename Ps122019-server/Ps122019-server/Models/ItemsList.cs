using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ps122019_server.Models
{
    public class ItemsList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
