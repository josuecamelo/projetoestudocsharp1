using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebEscola.Models;

namespace WebEscola.Data
{
    public class WebEscolaContext : DbContext
    {
        public WebEscolaContext (DbContextOptions<WebEscolaContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Aluno { get; set; }
    }
}
