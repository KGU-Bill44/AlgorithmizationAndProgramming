﻿using HomeWorkTen.Engine;

namespace HomeWorkTen.Ui
{
    public class ConsoleUi
    {
        /// <summary>
        /// Вход в консолное прилоджение.
        /// </summary>
        public static void Run()
        {
            PrintWelcome();
            PrintInfoTask();
            try
            {
                int n = GetNumberFromConsole("размер квадратичной матрицы N");

                if (n < 0)
                {
                    throw new ArgumentException("Матрца не может существовать, в которой одна из сторон меньше нуля.");
                }

                double[,] matrix = GetQuadraticMatrixCounts(n);
                PrintOfMatrix(matrix);
                double result = MatrixDiagonals.AverageSideDiagonal(matrix);

                Console.WriteLine($"Среднеарифметическое матициы = {result:f2}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введеная строка не соответсвует формату числа");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Число вышло за рамки допустимых значений");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }

        /// <summary>
        /// Выводит матрицу на экран.
        /// </summary>
        private static void PrintOfMatrix(double[,] matrix)
        {
            if (matrix.Length == 0)
            {
                Console.WriteLine("Матрица пустая");
                return;
            }

            Console.WriteLine("Получившеяся матрица:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]:f2}\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Выводит массив на консоль.
        /// </summary>
        private static void PrintArray(int[] result)
        {
            Console.Write("Результат: ");
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write($"{result[i]} \t");
            }
        }

        /// <summary>
        /// Метод чтений элементов массива из консоли.
        /// </summary>
        /// <param name="n">Количество элементов в массиве</param>
        /// <returns>Собранный элемент</returns>
        private static double[,] GetQuadraticMatrixCounts(int n)
        {
            double[,] array = new double[n, n];

            for (int indexOfLine = 0; indexOfLine < n; indexOfLine++)
            {
                for (int indexOfColumn = 0; indexOfColumn < n; indexOfColumn++)
                {
                    Console.Write($"Введите значение элемента {indexOfLine + 1}, {indexOfColumn + 1}: ");
                    double anyDouble = double.Parse(Console.ReadLine());
                    array[indexOfLine, indexOfColumn] = anyDouble;
                }
            }

            return array;
        }

        /// <summary>
        /// Выводит в консоль приветсвия для пользователя.
        /// </summary>
        private static void PrintWelcome()
        {
            Console.WriteLine("Приветсвую!");
        }

        /// <summary>
        /// Выводит в консоль информацию о решаемой задачи.
        /// </summary>
        private static void PrintInfoTask()
        {
            Console.Write("Программа находить среднее арефметическое побочной диаганали квадратной матрицы.\n");
        }

        /// <summary>
        /// Метод получения из консоли число.
        /// </summary>
        /// <returns>Число типа int</returns>
        /// <param name="nameForVarible">Название числа</param>
        private static int GetNumberFromConsole(string nameForVarible)
        {
            Console.Write($"Введите {nameForVarible}: ");
            string anyString = Console.ReadLine();
            return int.Parse(anyString);
        }
    }
}
