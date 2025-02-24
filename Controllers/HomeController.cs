using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using practica.Models;

namespace practica.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string cedula, string nombre, string apellido, int edad)
    {
        List<ClientModel> _listaCliente = new List<ClientModel>();
            var cliente = new ClientModel
            {
                LastName = "Apellido",
                Cedula_RUC = "Cedula",
                Address = "Santo Domingo",
                Email = "email",
                Age = edad,
                Gender = true,
                Id = 1,
                Name = "Nombre",
                Phone = "123456789",
                DateOfBirth = new DateOnly(1990, 1, 1)
            };
            _listaCliente.Add(cliente);
        return View(_listaCliente);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Client(string cedula, string nombre, string apellido, int edad) {
        List<ClientModel> _listaCliente = new List<ClientModel>();
            var cliente = new ClientModel
            {
                LastName = apellido,
                Cedula_RUC = cedula,
                Address = "Santo Domingo",
                Email = "raulduran@gmail.com",
                Age = edad,
                Gender = true,
                Id = 1,
                Name = nombre,

            };
            _listaCliente.Add(cliente);
        return View(_listaCliente);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
