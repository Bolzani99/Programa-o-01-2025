using Microsoft.AspNetCore.Mvc;
using NumeroPorExtenso.Models;

namespace NumeroPorExtenso.Controllers
{
    public class NumeroController : Controller
    {
        // Exibe o formulário para o usuário inserir o número
        public IActionResult Index()
        {
            return View();
        }

        // Processa o número enviado pelo formulário
        [HttpPost]
        public IActionResult Index(NumeroModel model)
        {
            if (ModelState.IsValid)
            {
                // Converte o número para extenso e armazena em ViewBag
                ViewBag.NumeroPorExtenso = NumeroParaExtenso(model.Numero);
            }
            return View(model);
        }

        // Método para converter o número em extenso
        private string NumeroParaExtenso(int numero)
        {
            if (numero == 0)
                return "zero";

            string[] unidades = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
            string[] dezenas = { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
            string[] centenas = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
            string[] milhares = { "", "mil" };

            string extenso = "";

            if (numero >= 1000)
            {
                extenso += milhares[numero / 1000] + " ";
                numero %= 1000;
            }

            if (numero >= 100)
            {
                extenso += centenas[numero / 100] + " ";
                numero %= 100;
            }

            if (numero >= 20)
            {
                extenso += dezenas[numero / 10] + " ";
                numero %= 10;
            }
            else if (numero >= 10)
            {
                extenso += dezenas[numero - 10] + " ";
                numero = 0;
            }

            if (numero > 0)
            {
                extenso += unidades[numero] + " ";
            }

            return extenso.Trim();
        }
    }
}