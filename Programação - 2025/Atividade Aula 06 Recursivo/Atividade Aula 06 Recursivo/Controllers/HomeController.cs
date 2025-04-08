using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Atividade_Aula_06_Recursivo.Models;

namespace Atividade_Aula_06_Recursivo.Controllers;

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
    public string PrintDescendingRec(int n = 10)
    {
        if (n < 1)
            return "O n�mero deve ser maior ou igual a 1";

        return DescendingRecursion(n);
    }

    private string DescendingRecursion(int n)
    {
        // Caso base: quando n for 1, retorna "1"
        if (n == 1)
            return "1";

        // Chamada recursiva: imprime o n�mero atual e chama a fun��o com n-1
        return $"{n} " + DescendingRecursion(n - 1);
    }

    [HttpGet]
    public string SumNumbersRec(int n = 10)
    {
        if (n < 1)
            return "O n�mero deve ser maior ou igual a 1";

        int sum = SumRecursion(n);
        return $"A soma dos n�meros de 1 a {n} �: {sum}";
    }

    private int SumRecursion(int n)
    {
        // Caso base: quando n for 1, retorna 1
        if (n == 1)
            return 1;

        // Chamada recursiva: soma o n�mero atual com a soma dos anteriores
        return n + SumRecursion(n - 1);
    }

    [HttpGet]
    public string CountCharsRec(string palavra = "recursividade")
    {
        if (string.IsNullOrEmpty(palavra))
            return "A string n�o pode ser vazia";

        int count = CountChars(palavra);
        return $"A palavra '{palavra}' tem {count} caracteres";
    }

    private int CountChars(string palavra)
    {
        // Caso base: string vazia
        if (string.IsNullOrEmpty(palavra))
            return 0;

        // Chamada recursiva: conta 1 caractere e chama a fun��o com o restante da string
        return 1 + CountChars(palavra.Substring(1));
    }
    [HttpGet]
    public string CheckPalindromeRec(string palavra = "arara")
    {
        if (string.IsNullOrEmpty(palavra))
            return "A string n�o pode ser vazia";

        bool isPalindrome = IsPalindrome(palavra.ToLower()); // converter para min�sculas para evitar problemas com mai�sculas/min�sculas
        return $"A palavra '{palavra}' {(isPalindrome ? "�" : "n�o �")} um pal�ndromo";
    }

    private bool IsPalindrome(string palavra)
    {
        // Caso base: string vazia ou com 1 caractere sempre � pal�ndromo
        if (palavra.Length <= 1)
            return true;

        // Verifica se o primeiro e �ltimo caracteres s�o iguais
        if (palavra[0] != palavra[palavra.Length - 1])
            return false;

        // Chamada recursiva: verifica o restante da string (sem o primeiro e �ltimo caracteres)
        return IsPalindrome(palavra.Substring(1, palavra.Length - 2));
    }

}   

