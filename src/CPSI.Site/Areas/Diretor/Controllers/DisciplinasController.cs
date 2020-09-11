using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPSI.Negocio.Interface;
using CPSI.Negocio.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPSI.Site.Areas.Diretor.Controllers
{   
    [Area("Diretor")]
    [Authorize]
    public class DisciplinasController : Controller
    {
        private readonly IDisciplinaService _disciplinaService;
        
        public DisciplinasController(IDisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;             
        }

        public async Task<IActionResult> Listar()
        {
            return View(await _disciplinaService.ObterTodos());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(IFormCollection form)
        {
            Disciplina disciplina = new Disciplina();
            disciplina.Nome = form["Nome"];

            await _disciplinaService.Adicionar(disciplina);

            return RedirectToAction("Listar");
        }

        [HttpGet("Diretor/Disciplinas/Detalhar/{Id:int}")]
        public async Task<IActionResult> Detalhar(int Id)
        {
            Disciplina disciplina = await _disciplinaService.ObterPorId(Id);

            return View(disciplina);
        }

        public async Task<IActionResult> Editar(int Id)
        {
            Disciplina disciplina = await _disciplinaService.ObterPorId(Id);
            return View(disciplina);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Disciplina disciplina)
        {
           await _disciplinaService.Atualizar(disciplina);
           return RedirectToAction("Detalhar", new {id = disciplina.Id });
        }
    }
}