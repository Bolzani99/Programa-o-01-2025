using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Aula_06___Recursividade.Models;

namespace Aula_06___Recursividade.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public string PrintNaturalFor(int n = 10)
    {
        string retorno = string.Empty;

        int i = 1;
        while (i <=n)
        {
            retorno += $" {i} ";
            i++;
        }



        return retorno;
    }


    [HttpGet]
    public string PrintNaturalRec(int count  = 10)
    {
        string retorno = "";

        retorno = NaturalNumberRecursion(1, count);

        return retorno;
    }

    public string NaturalNumberRecursion(int n, int count)
    {
        string ret = string.Empty;

        // Caso base: Se o contador for menor que 1
        if (count < 1)
            return $"{n}";

        ret += $"{n} ";
        count --; // decrementa count 

        ret += NaturalNumberRecursion(n + 1, count);
        // Chamada recursiva: incrementa n e decrementa count para imprimir o número
        


        return ret;
    }
}
