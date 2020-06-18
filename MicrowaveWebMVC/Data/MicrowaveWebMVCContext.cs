using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MicrowaveWebMVC.Models
{
    public class MicrowaveWebMVCContext : DbContext
    {
        public MicrowaveWebMVCContext (DbContextOptions<MicrowaveWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<MicrowaveWebMVC.Models.ProgramType> ProgramType { get; set; }
    }
}
