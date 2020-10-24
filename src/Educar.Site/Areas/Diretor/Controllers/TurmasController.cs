using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Educar.Negocio.Interface;
using Educar.Negocio.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Educar.Site.Areas.Diretor.Controllers
{
    [Area("Diretor")]
    [Authorize]
    public class TurmasController : Controller
    {
        private readonly ITurmaService _turmaService;
        private readonly IDisciplinaService _DisciplinaService;

        public TurmasController(ITurmaService _turmaService, IDisciplinaService _DisciplinaService)
        {
            this._turmaService      = _turmaService;
            this._DisciplinaService = _DisciplinaService;
        }
        
        public async Task<IActionResult> Listar()
        {
            return View(await _turmaService.ObterTurmasComDisciplinas());
        }

        public IActionResult Cadastrar() 
        {
            ViewBag.Disciplinas = _DisciplinaService.ObterTodos().Result.ToList();
            return View();
        }

        public async Task<IActionResult> Editar(int Id)
        {
            Turma turma = await _turmaService.ObterTurma(Id);

            ViewBag.Disciplinas = _DisciplinaService.ObterTodos().Result.ToList();
            return View(turma);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromForm]Turma turma)
        {
            await _turmaService.Adicionar(turma);
            return RedirectToAction("Detalhar", new { Id = turma.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Turma turma)
        {
            await _turmaService.Atualizar(turma);
            return RedirectToAction("Detalhar", new {Id = turma.Id});
        }

        [HttpGet("Diretor/Turmas/Detalhar/{Id:int}")]
        public async Task<IActionResult> Detalhar(int Id) 
        {
            Turma turma = await _turmaService.ObterTurma(Id);
            return View(turma);
        }
    }
}