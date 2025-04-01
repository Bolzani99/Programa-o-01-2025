using Microsoft.AspNetCore.Mvc;
using System;

namespace Aula_05_IF.Controllers
{
    public class JogoVelhaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Inicializa o tabuleiro vazio
            ViewBag.Tabuleiro = new string[3, 3];
            ViewBag.Vencedor = null;
            ViewBag.JogadorAtual = "X";
            ViewBag.Empate = false;
            return View();
        }

        [HttpPost]
        public IActionResult Index(
            string A00, string A01, string A02,
            string A10, string A11, string A12,
            string A20, string A21, string A22,
            string jogadorAtual)
        {
            string[,] matrixTTT = new string[3, 3];
            matrixTTT[0, 0] = A00;
            matrixTTT[0, 1] = A01;
            matrixTTT[0, 2] = A02;

            matrixTTT[1, 0] = A10;
            matrixTTT[1, 1] = A11;
            matrixTTT[1, 2] = A12;

            matrixTTT[2, 0] = A20;
            matrixTTT[2, 1] = A21;
            matrixTTT[2, 2] = A22;

            // Verifica o vencedor
            string vencedor = VerificarVencedor(matrixTTT);
            bool empate = false;

            // Se não há vencedor, alterna o jogador
            string novoJogador = jogadorAtual;
            if (vencedor == null)
            {
                novoJogador = jogadorAtual == "X" ? "O" : "X";

                // Verifica empate
                empate = VerificarEmpate(matrixTTT);
            }

            ViewBag.Tabuleiro = matrixTTT;
            ViewBag.Vencedor = vencedor;
            ViewBag.JogadorAtual = novoJogador;
            ViewBag.Empate = empate;

            return View();
        }

        private string VerificarVencedor(string[,] tabuleiro)
        {
            // Verifica linhas
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(tabuleiro[i, 0]) &&
                    tabuleiro[i, 0] == tabuleiro[i, 1] &&
                    tabuleiro[i, 1] == tabuleiro[i, 2])
                {
                    return tabuleiro[i, 0];
                }
            }

            // Verifica colunas
            for (int j = 0; j < 3; j++)
            {
                if (!string.IsNullOrEmpty(tabuleiro[0, j]) &&
                    tabuleiro[0, j] == tabuleiro[1, j] &&
                    tabuleiro[1, j] == tabuleiro[2, j])
                {
                    return tabuleiro[0, j];
                }
            }

            // Verifica diagonais
            if (!string.IsNullOrEmpty(tabuleiro[0, 0]) &&
                tabuleiro[0, 0] == tabuleiro[1, 1] &&
                tabuleiro[1, 1] == tabuleiro[2, 2])
            {
                return tabuleiro[0, 0];
            }

            if (!string.IsNullOrEmpty(tabuleiro[0, 2]) &&
                tabuleiro[0, 2] == tabuleiro[1, 1] &&
                tabuleiro[1, 1] == tabuleiro[2, 0])
            {
                return tabuleiro[0, 2];
            }

            return null;
        }

        private bool VerificarEmpate(string[,] tabuleiro)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrEmpty(tabuleiro[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}