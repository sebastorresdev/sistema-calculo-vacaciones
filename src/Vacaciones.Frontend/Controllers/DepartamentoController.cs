using Microsoft.AspNetCore.Mvc;
using Vacaciones.Datos.Entities;
using Vacaciones.Frontend.Models.Departamentos;
using Vacaciones.Negocios.Services;

namespace Vacaciones.Frontend.Controllers;

public class DepartamentoController : Controller
{
    private readonly DepartamentoService _departamentoService;

    public DepartamentoController(DepartamentoService departamentoService)
    {
        _departamentoService = departamentoService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var viewModels = _departamentoService.GetDepartamentos().Select(d => new DepartamentoViewModel(d.Id, d.Nombre)).ToList();

        return View(viewModels);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateDepartamentoViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            Departamento departamento = new()
            {
                Nombre = viewModel.Nombre
            };
            _departamentoService.AddDepartamento(departamento);
            return RedirectToAction("Index");
        }
        return View(viewModel);
    }

    public IActionResult Edit(int id)
    {
        var departamento = _departamentoService.GetDepartamentoById(id);

        if (departamento == null)
        {
            return NotFound();
        }

        var viewModel = new EditDepartamentoViewModel
        {
            Id = departamento.Id,
            Nombre = departamento.Nombre
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Edit(EditDepartamentoViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            Departamento departamento = new()
            {
                Id = viewModel.Id,
                Nombre = viewModel.Nombre
            };
            _departamentoService.UpdateDepartamento(departamento);
            return RedirectToAction("Index");
        }
        return View(viewModel);
    }
}