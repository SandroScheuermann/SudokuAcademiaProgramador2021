using System;
using System.Collections.Generic;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrizSudoku = new int[,] { //declarando o sudoku apresentado
                     {1,3,2,5,7,9,4,6,8},
                     {4,9,8,2,6,1,3,7,5},
                     {7,5,6,3,8,4,2,1,9},
                     {6,4,3,1,5,8,7,9,2},
                     {5,2,1,7,9,3,8,4,6},
                     {9,8,7,4,2,6,5,3,1},
                     {2,1,4,9,3,5,6,8,7},
                     {3,6,5,8,1,7,9,2,4},
                     {8,7,9,6,4,2,1,5,3}};

            printaSudoku(matrizSudoku);

            verificarSudoku(matrizSudoku);

        }

        private static void printaSudoku(int[,] matrizSudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine();

                for (int j = 0; j < 9; j++)
                {
                    Console.Write(matrizSudoku[i, j] + " ");
                }
            }

            Console.WriteLine();
        }


        // Utilizei o HashSet, que é uma espécie de tabela que não aceita números repetidos,
        // e retorna um boolean na função .Add, dentro da lógica dos for aninhados, fiz os métodos
        // para verificar a parte 3x3, linhas e colunas.
        // Tem um método verificarSudoku que é só um if else com os booleans retornados dos outros métodos, caso algum for FALSE, vai ser printado NÃO.


        private static bool verificarQuadrados(int[,] matriz)
        {
            HashSet<int> tabelaNumero = new HashSet<int>();
            bool ok = true;

            for (int y = 0; y < 9; y += 3)
            {
                for (int x = 0; x < 9; x += 3)
                {
                    tabelaNumero = new HashSet<int>();

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            ok = tabelaNumero.Add(matriz[i + y, j + x]);
                            if (!ok)
                            {
                                return ok;
                            }
                        }
                    }
                }
            }
            return ok;
        }

        private static bool verificarColunas(int[,] matriz)
        {
            bool ok = true;

            for (int j = 0; j < 9; j++)
            {
                HashSet<int> tabelaNumero = new HashSet<int>();
                for (int i = 0; i < 9; i++)
                {
                    ok = tabelaNumero.Add(matriz[i, j]);
                    if (!ok) { return ok; }
                }
            }
            return ok;
        }

        private static bool verificarLinhas(int[,] matriz)
        {
            bool ok = true;

            for (int i = 0; i < 9; i++)
            {
                HashSet<int> tabelaNumero = new HashSet<int>();
                for (int j = 0; j < 9; j++)
                {
                    ok = tabelaNumero.Add(matriz[i, j]);
                    if (!ok) { return ok; }
                }
            }
            return ok;
        }
        private static void verificarSudoku(int[,] matrizSudoku)
        {
            if (verificarColunas(matrizSudoku) && verificarLinhas(matrizSudoku) && verificarQuadrados(matrizSudoku))
            {
                Console.WriteLine("\nSIM");
            }
            else
            {
                Console.WriteLine("\nNÃO");
            }

            Console.ReadLine();
        }


    }

}