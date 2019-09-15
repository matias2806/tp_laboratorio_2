using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region validar Operador
        /// <summary>
        /// Verifica que le pasen un operador valido en el caso de que pasen algo erroneo devuelve una suma ( + )
        /// </summary>
        /// <param name="operador"> es el param a validar </param>
        /// <returns> el operador correspondiente si no paso la validacion devuelve + </returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if(operador == "-" || operador == "*" || operador == "/")
            {
                retorno = operador;
            }
            return retorno;
        }
        #endregion

        #region Operar

        /// <summary>
        /// Realiza la operacion de dos Num (atributo numero ) valida el operador
        /// </summary>
        /// <param name="num1">numero 1 a realizar la operacion matematica</param>
        /// <param name="num2">numero 2 a realizar la operacion matematica</param>
        /// <param name="operador">operacion a ser resuelta</param>
        /// <returns>respuesta de dicha operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string operadorValidado = ValidarOperador(operador);
            double resultado =0;

            switch (operadorValidado)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }//no uso default ya que estan contemplados todos los casos ademas asi queda mas prolijo

            return resultado;
        }
        #endregion

    }
}
