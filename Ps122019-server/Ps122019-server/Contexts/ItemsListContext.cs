using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ps122019_server.Models;

namespace Ps122019_server.Contexts
{
    public class ItemsListContext : DbContext
    {
        public ItemsListContext(DbContextOptions<ItemsListContext> options) : base(options)
        {

        }
        public DbSet<ItemsList> ItemsList { get; set; }
    }
}
