using Microsoft.AspNetCore.Mvc;
using Vacaciones.Datos.Entities;
using Vacaciones.Frontend.Mappings;
using Vacaciones.Frontend.Models.Departamento;
using Vacaciones.Negocios.Interfaces;

namespace Vacaciones.Frontend.Controllers;

public class DepartamentoController : Controller
{
    private readonly IDepartamentoService _departamentoService;

    public DepartamentoController(IDepartamentoService departamentoService)
    {
        _departamentoService = departamentoService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var viewModels = _departamentoService.GetAll()
            .Select(d => d.ToDepartamentoViewModel())
            .ToList();

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
            Departamento departamento = viewModel.ToDepartamento();

            _departamentoService.Save(departamento);

            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }

    public IActionResult Edit(int id)
    {
        var departamento = _departamentoService.GetById(id);

        if (departamento == null)
        {
            return NotFound();
        }

        var viewModel = departamento.ToEditDepartamentoViewModel();

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Edit(EditDepartamentoViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            Departamento departamento = viewModel.ToDepartamento();
            
            _departamentoService.Update(departamento);

            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _departamentoService.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}