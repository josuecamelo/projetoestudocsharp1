using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebEscola.Data;
using WebEscola.Models;
using System;
using System.Linq;

namespace WebEscola.Models
{
    public static class SeedData

    {

        public static void Initialize(IServiceProvider serviceProvider)

        {

            using (var context = new WebEscolaContext(

                serviceProvider.GetRequiredService<DbContextOptions<WebEscolaContext>>()))

            {

                if (context.Aluno.Any()) { return; }

                context.Aluno.AddRange(
                    new Aluno { Nome = "Alberto", Sobrenome = "Almeida", Data = DateTime.Parse("1989-2-12"), Estado = "MG" },
                    new Aluno { Nome = "Marcelo", Sobrenome = "Barros", Data = DateTime.Parse("1970-8-22"), Estado = "RJ" },
                    new Aluno { Nome = "Henrique", Sobrenome = "Carvalho", Data = DateTime.Parse("1990-5-07"), Estado = "SP" },
                    new Aluno { Nome = "Daniel", Sobrenome = "Freitas", Data = DateTime.Parse("1999-12-22"), Estado = "SP" },
                    new Aluno { Nome = "Fábio", Sobrenome = "Henrique", Data = DateTime.Parse("1993-9-17"), Estado = "BA" },
                    new Aluno { Nome = "Fernanda", Sobrenome = "Machado", Data = DateTime.Parse("1979-9-12"), Estado = "RS" },
                    new Aluno { Nome = "Cristina", Sobrenome = "Miranda", Data = DateTime.Parse("2001-12-25"), Estado = "RS" }
                );

                context.SaveChanges();
            }
        }
    }
}