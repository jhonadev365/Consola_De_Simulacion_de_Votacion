using System;
using System.Collections.Generic;
using System.Linq;
namespace Repaso_Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------4------------------------");
            votacion();
        }
        public static int[] mayor(int a, int b, int c, int d) {

            int[] resultado = new int[4];

            if (a >= b)
            {
                if (b >= c)
                {
                    if (c >= d)
                    {
                        return new int[] { a, b, c, d };
                    }
                    else if (d >= a)
                    {
                        return new int[] { d, a, b, c };
                    }
                    else if (d >= b)
                    {
                        return new int[] { a, d, b, c };
                    }
                    else
                    {
                        return new int[] { a, b, d, c };
                    }
                }
                else if (a >= c)
                {
                    if (b >= d)
                    {
                        return new int[] { a, c, b, d };
                    }
                    else if (d >= c)
                    {
                        return new int[] { a, d, c, b };
                    }
                    else if (d >= a)
                    {
                        return new int[] { d, a, c, b };
                    }
                    else
                    {
                        return new int[] { a, c, d, b };
                    }
                }
            }
            else
            {
                if (c>=a)
                {
                    if (d>=a)
                    {
                        return new int[] { b, c, d, a };
                    }
                    else if (d >= c)
                    {
                        return new int[] { b, d, c, a };
                    }
                    else if (d >= b)
                    {
                        return new int[] { d, b, c, a };
                    }
                    else
                    {
                        return new int[] { b, c, a, d };
                    }
                }
                else
                {
                    if (c>=d)
                    {
                        return new int[] { b, a, c, d };
                    }
                    else if (d >= a)
                    {
                        return new int[] { b, d, a, c };
                    }
                    else if (d >= b)
                    {
                        return new int[] { d, b, a, c };
                    }
                    else
                    {
                        return new int[] { b, a, d, c };
                    }
                }
            }

            return resultado;
        
        }
        public static void votacion() {
            int cantidadUsusarios = 50;
            int Candidatos = 4;
            int Total_1Candidato = 0, Total_2Candidato = 0, Total_3Candidato = 0, Total_4Candidato = 0;
            int voto = 0;
            Random eleccion = new Random();
            int[,] resultados = new int[cantidadUsusarios,Candidatos];
            for (int i = 0; i < cantidadUsusarios; i++)
            {
                voto = eleccion.Next(0, 4);
                for (int j = 0; j < Candidatos; j++)
                {
                    
                    if (j == voto)
                    {
                        resultados[i, j] = 1;
                        //  conteo de votos
                        if (voto == 0)
                        {
                            Total_1Candidato++;
                        }
                        else if (voto == 1)
                        {
                            Total_2Candidato++;
                        }
                        else if (voto == 2)
                        {
                            Total_3Candidato++;
                        }
                        else {
                            Total_4Candidato++;
                        }
                    }
                    else {
                        resultados[i, j] = 0;
                    }
                }
            }
            for (int i = 0; i < cantidadUsusarios; i++)
            {

                if (i < 9)
                {
                    Console.Write($"Usuario N° {i + 1}   | ");

                }
                else
                {
                    Console.Write($"Usuario N° {i + 1}  | ");
                }
                for (int j = 0; j < Candidatos; j++)
                {
                    if (resultados[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(" "+resultados[i, j]+" ");
                    
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("");
            }

            Console.WriteLine("---------CANTIDAD DE VOTOS POR CANDIDATO--------");

            Dictionary<string, int> keyValuePair = new Dictionary<string, int>() {
                { "Ivan Arias", Total_1Candidato},
                { "Cesar Dockeweiler", Total_2Candidato},
                { "Luis Larra", Total_3Candidato},
                { "Juan Carlos Arana", Total_4Candidato},
            };

            foreach (var item in keyValuePair)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }

            Console.WriteLine("---------POSICION--------");
            int [] posicion = mayor(Total_1Candidato, Total_2Candidato, Total_3Candidato, Total_4Candidato);
            
            Console.WriteLine("----------GANADOR--------");

            foreach (var item in keyValuePair)
            {
                if (item.Value == posicion[0])
                {
                    Console.WriteLine($"{item.Key} con {item.Value} votos ({ (item.Value / 50.0) * 100}%)");
                    break;
                }
            }
            Console.WriteLine();

            Console.WriteLine("---------PORCENTAJES--------");
            foreach (var item in keyValuePair)
            {
                double valor_porcentaje = Math.Round((item.Value / 50.0) * 100, 0);

                Console.WriteLine($"{item.Key} con {item.Value} votos ({valor_porcentaje}%)");
            }
            /*---------------------*/

        }
    }
}
