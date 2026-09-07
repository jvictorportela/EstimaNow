using EstimaNow.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstimaNow.Web.Controllers;

public class ClientsController : Controller
{
    public IActionResult Index()
    {
        return View(new List<ClientModel>());
    }
}
