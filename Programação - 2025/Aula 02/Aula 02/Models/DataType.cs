namespace Aula_02.Models
{
    public class DataType
    {
        public char myVar = 'a';
        public char myConst = 'b';    

        public char myChar1 = 'f';
        public char myChar2 = ':';
        public char myChar3 = 'x';

        // podemos também atribuir referencia de caracteres unicode 

        public char myChar4 = '\u2726'; 
       
        // podemos ainda mesclar caracteres especiais como, nova linha, tabulação etc.
        public string textLine = "Esta é uma linha de texto.\n\n\n E esta é outra linha";

        /*
            \e caracter de escape
            \n nova linha
            \r retorno 
            \e Tabulação horizontal
            \" aspas duplas, usadas para exibir aspas dentro de string    
            \' aspas simples, usadas para exibir aspas dentro de string 
        */

        private int count = 10;
        public string message;
        
        public DataType()
        {
            //interpolando strings 
            // combinando strings de diferentes maneiras no c#
            message = $"O contador esta em {count}";

            string username = "Silvio Bolzani";
            int inboxCount = 10;
            int maxCount = 100;

            message += $"\nO usurario {username}, tem {inboxCount} mensagens.";
            message += $"\nEspaço restante em sua caixa {maxCount - inboxCount}.";
        }


    }
}
