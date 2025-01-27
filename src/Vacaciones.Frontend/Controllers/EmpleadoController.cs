using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vacaciones.Frontend.Mappings;
using Vacaciones.Frontend.Models.Departamento;
using Vacaciones.Frontend.Models.Empleado;
using Vacaciones.Negocios.Interfaces;

namespace Vacaciones.Frontend.Controllers;
public class EmpleadoController : Controller
{
    private readonly IEmpleadoService _empleadoService;
    private readonly IDepartamentoService _departamentoService;
    private readonly ITipoEmpleadoService _tipoEmpleadoService;

    public EmpleadoController(IEmpleadoService empleadoService, IDepartamentoService departamentoService, ITipoEmpleadoService tipoEmpleadoService)
    {
        _empleadoService = empleadoService;
        _departamentoService = departamentoService;
        _tipoEmpleadoService = tipoEmpleadoService;
    }

    public IActionResult Index()
    {
        var empleados = _empleadoService.GetAll().Select(e => e.ToEmpleadoViewModel());

        return View(empleados);
    }

    public IActionResult Create()
    {
        ViewBag.Departamentos = new SelectList(_departamentoService.GetAll(), "Id", "Nombre");

        ViewBag.TiposEmpleados = new SelectList(_tipoEmpleadoService.GetAll(), "Id", "Nombre");

        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateEmpleadoViewModel request)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Departamentos = new SelectList(_departamentoService.GetAll(), "Id", "Nombre");

            ViewBag.TiposEmpleados = new SelectList(_tipoEmpleadoService.GetAll(), "Id", "Nombre");

            TempData["SuccessMessage"] = "Empleado guardado correctamente.";

            return View(request);
        }

        _empleadoService.Create(request.ToEmpleado());

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var empleado = _empleadoService.GetById(id);

        if (empleado == null)
        {
            return NotFound();
        }


        ViewBag.Departamentos = new SelectList(_departamentoService.GetAll(), "Id", "Nombre");

        ViewBag.TiposEmpleados = new SelectList(_tipoEmpleadoService.GetAll(), "Id", "Nombre");

        return View(empleado.ToEditEmpleadoViewModel());
    }

    [HttpPost]
    public IActionResult Edit(EditEmpleadoViewModel request)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Departamentos = new SelectList(_departamentoService.GetAll(), "Id", "Nombre");
            ViewBag.TiposEmpleados = new SelectList(_tipoEmpleadoService.GetAll(), "Id", "Nombre");
            return View(request);
        }
        
        _empleadoService.Update(request.ToEmpleado());
        
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _empleadoService.Delete(id);

        return RedirectToAction("Index");
    }
}
