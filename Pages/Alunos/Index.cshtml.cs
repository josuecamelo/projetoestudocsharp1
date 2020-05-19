using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebEscola.Data;
using WebEscola.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebEscola.Pages.Alunos
{
    public class IndexModel : PageModel
    {
        private readonly WebEscolaContext _context;

        public IndexModel(WebEscolaContext context)
        {
            _context = context;
        }

        public PaginatedList<Aluno> Aluno { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BuscaNome { get; set; }

        public string NameSort { get; set; }

        public string DateSort { get; set; }

        public SelectList Estados { get; set; }

        [BindProperty(SupportsGet = true)]

        public string EstadoAluno { get; set; }

        public string FilterNome { get; set; }

        public string FilterEstado { get; set; }

        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string filterNome, string filterEstado, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (BuscaNome != null)
            {
                pageIndex = 1;
            }
            else
            {
                BuscaNome = filterNome;
            }

            FilterNome = BuscaNome;

            if (EstadoAluno != null)
            {
                pageIndex = 1;
            }
            else
            {
                EstadoAluno = filterEstado;
            }

            FilterEstado = EstadoAluno;

            IQueryable<string> listaEstado = from m in _context.Aluno
                                             orderby m.Estado
                                             select m.Estado;
            Estados = new SelectList(await listaEstado.Distinct().ToListAsync());

            var alunos = from m in _context.Aluno
                         select m;

            if (!string.IsNullOrEmpty(BuscaNome))
            {
                alunos = alunos.Where(s => s.Nome.Contains(BuscaNome));
            }

            if (!string.IsNullOrEmpty(EstadoAluno))
            {
                alunos = alunos.Where(x => x.Estado == EstadoAluno);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    alunos = alunos.OrderByDescending(s => s.Nome);
                    break;
                case "Date":
                    alunos = alunos.OrderBy(s => s.Data);
                    break;
                case "date_desc":
                    alunos = alunos.OrderByDescending(s => s.Data);
                    break;
                default:
                    alunos = alunos.OrderBy(s => s.Nome);
                    break;
            }

            int pageSize = 3;
            Aluno = await PaginatedList<Aluno>.CreateAsync(
                alunos.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}