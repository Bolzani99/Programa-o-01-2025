using System.Runtime.InteropServices.JavaScript;
using System;

namespace Aula_01.Models
{
    public class Variaveis
    {
        // Tipos implicitos 
        //var teste = 10;

        // Anotação de Tipos
        public int userCount = 10;

        // Uma variável pode ser declarada e nao inicializada 
        public int totalCount;

        //CONSTANTES
        // Para declarar uma constante utulizamos a palavra-chave CONST 
        // no entanto a CONST deve ser inicializada quando declarada
        public const int interestRate = 10;


        public Byte myByte = new Byte();
        public Int myInt = new Int();
        public Long myLong = new Long();
        public Sbyte mySbyte = new Sbyte();
        public Short myShort = new Short();
        public Uint myUint = new Uint();
        public Ulong myUlong = new Ulong();
        public Ushort myUshort = new Ushort();

        // O Método contrutor é invocado na instaciação do objeto por meio da palavra reservada new.
        // Por regra, o contrutor sempre tem o mesmo nome da classe. 
        public Variaveis()
        {
            totalCount = 0;

            // Tipop implicito
            // A palavra chaver var se encarrega de definir o tipo da variavel na instrução de atribuição. 
            var signalStrength = 22;
            var companyName = "ACME";

        }
    }
}
