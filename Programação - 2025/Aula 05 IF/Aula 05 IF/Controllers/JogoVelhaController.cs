using Microsoft.AspNetCore.Mvc;

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
            string A20, string A21, string A22)
        {
            // Preenche a matriz 3x3 com os valores recebidos
            string[,] matrixTTT = new string[3, 3];
            matrixTTT[0, 0] = A00?.ToUpper();
            matrixTTT[0, 1] = A01?.ToUpper();
            matrixTTT[0, 2] = A02?.ToUpper();

            matrixTTT[1, 0] = A10?.ToUpper();
            matrixTTT[1, 1] = A11?.ToUpper();
            matrixTTT[1, 2] = A12?.ToUpper();

            matrixTTT[2, 0] = A20?.ToUpper();
            matrixTTT[2, 1] = A21?.ToUpper();
            matrixTTT[2, 2] = A22?.ToUpper();

            // Verifica se há um vencedor
            string vencedor = VerificarVencedor(matrixTTT);
            bool empate = false;

            // Se não há vencedor, verifica empate
            if (vencedor == null)
            {
                empate = VerificarEmpate(matrixTTT);
            }

            // Prepara os dados para a view
            ViewBag.Tabuleiro = matrixTTT;
            ViewBag.Vencedor = vencedor;
            ViewBag.Empate = empate;
            ViewBag.JogadorAtual = vencedor == null && !empate ?
                (ViewBag.JogadorAtual == "X" ? "O" : "X") :
                ViewBag.JogadorAtual;

            return View();
        }

        private string VerificarVencedor(string[,] tabuleiro)
        {
            // Verifica linhas (índice de linhas iguais)
            for (int linha = 0; linha < 3; linha++)
            {
                if (!string.IsNullOrEmpty(tabuleiro[linha, 0]) &&
                    tabuleiro[linha, 0] == tabuleiro[linha, 1] &&
                    tabuleiro[linha, 1] == tabuleiro[linha, 2])
                {
                    return tabuleiro[linha, 0];
                }
            }

            // Verifica colunas (índice de colunas iguais)
            for (int coluna = 0; coluna < 3; coluna++)
            {
                if (!string.IsNullOrEmpty(tabuleiro[0, coluna]) &&
                    tabuleiro[0, coluna] == tabuleiro[1, coluna] &&
                    tabuleiro[1, coluna] == tabuleiro[2, coluna])
                {
                    return tabuleiro[0, coluna];
                }
            }

            // Verifica diagonal principal (índice linha == índice coluna)
            if (!string.IsNullOrEmpty(tabuleiro[0, 0]) &&
                tabuleiro[0, 0] == tabuleiro[1, 1] &&
                tabuleiro[1, 1] == tabuleiro[2, 2])
            {
                return tabuleiro[0, 0];
            }

            // Verifica diagonal secundária (índice linha + índice coluna = 2)
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