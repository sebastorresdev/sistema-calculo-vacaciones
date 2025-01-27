using Microsoft.AspNetCore.Mvc;
using Vacaciones.Frontend.Mappings;
using Vacaciones.Frontend.Models.TipoEmpleado;
using Vacaciones.Negocios.Interfaces;

namespace Vacaciones.Frontend.Controllers;
public class TipoEmpleadoController : Controller
{
    private readonly ITipoEmpleadoService _tipoEmpleadoService;

    public TipoEmpleadoController(ITipoEmpleadoService tipoEmpleadoService)
    {
        _tipoEmpleadoService = tipoEmpleadoService;
    }

    public IActionResult Index()
    {
        var tiposEmpleados = _tipoEmpleadoService.GetAll().Select(te => new TipoEmpleadoViewModel
        {
            Id = te.Id,
            Nombre = te.Nombre,
            DiasPorAnio = te.DiasPorAnio
        });

        return View(tiposEmpleados);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateTipoEmpleadoViewModel createTipoEmpleadoViewModel)
    {
        if (ModelState.IsValid)
        {
            var tipoEmpleado = createTipoEmpleadoViewModel.ToTipoEmpleado();

            _tipoEmpleadoService.Save(tipoEmpleado);

            return RedirectToAction(nameof(Index));
        }

        return View(createTipoEmpleadoViewModel);
    }

    public IActionResult Edit(int id)
    {
        var tipoEmpleado = _tipoEmpleadoService.GetById(id);
        
        if (tipoEmpleado == null)
        {
            return NotFound();
        }

        var viewModel = tipoEmpleado.ToEditTipoEmpleadoViewModel();

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Edit(EditTipoEmpleadoViewModel editTipoEmpleadoViewModel)
    {
        if (ModelState.IsValid)
        {
            var tipoEmpleado = editTipoEmpleadoViewModel.ToTipoEmpleado();

            _tipoEmpleadoService.Update(tipoEmpleado);

            return RedirectToAction(nameof(Index));
        }

        return View(editTipoEmpleadoViewModel);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _tipoEmpleadoService.Delete(id);
        
        return RedirectToAction(nameof(Index));
    }
}