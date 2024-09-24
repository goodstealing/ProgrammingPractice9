using System;

namespace Module1_3
{
    internal class Task3
    {
        public static void Execute()
        {
            Console.Clear();
            Console.CursorVisible = true;

           
            Console.Write("Введите размер квадратной матрицы N: ");
            int N = int.Parse(Console.ReadLine());
            int[,] matrix = GenerateRandomMatrix(N);
            Console.CursorVisible = false;

            Console.WriteLine("Сгенерированная матрица:");
            PrintMatrix(matrix);
            // Упорядочивание строк по возрастанию сумм их элементов
            SortRowsBySum(matrix);

            Console.WriteLine("Матрица после сортировки строк по суммам:");
            PrintMatrix(matrix);
            
        }

        /// <summary>
        /// Генерирует квадратную целочисленную матрицу со случайными значениями.
        /// </summary>
        /// <param name="size">Размер матрицы (строки и столбцы).</param>
        /// <returns>Сгенерированная матрица.</returns>
        private static int[,] GenerateRandomMatrix(int size)
        {
            Random random = new(); 
            int[,] matrix = new int[size, size]; 

            // Заполнение матрицы случайными числами в диапазоне от -50 до 50
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(-50, 51); 
                }
            }
            return matrix;
        }

        /// <summary>
        /// Выводит матрицу в консоль.
        /// </summary>
        /// <param name="matrix">Матрица для вывода.</param>
        private static void PrintMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0); // Получение размера матрицы (число строк)

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4)); // Вывод элемента с отступом
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Упорядочивает строки матрицы по возрастанию сумм их элементов.
        /// </summary>
        /// <param name="matrix">Матрица для сортировки.</param>
        private static void SortRowsBySum(int[,] matrix)
        {
            int size = matrix.GetLength(0);  // Получение размера матрицы (число строк)

            // Сортирование строк матрицы на основе сумм элементов
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    // Если сумма строки j больше суммы строки j+1 обмен их местами
                    if (GetRowSum(matrix, j) > GetRowSum(matrix, j + 1))
                    {
                        SwapRows(matrix, j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Получает сумму элементов заданной строки матрицы.
        /// </summary>
        /// <param name="matrix">Матрица, из которой берется строка.</param>
        /// <param name="row">Индекс строки, сумму которой нужно вычислить.</param>
        /// <returns>Сумма элементов строки.</returns>
        private static int GetRowSum(int[,] matrix, int row)
        {
            int sum = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[row, j]; // Суммирование элементов строки
            }
            return sum;
        }

        /// <summary>
        /// Меняет местами две строки матрицы.
        /// </summary>
        /// <param name="matrix">Матрица, в которой нужно поменять строки.</param>
        /// <param name="row1">Индекс первой строки.</param>
        /// <param name="row2">Индекс второй строки.</param>
        private static void SwapRows(int[,] matrix, int row1, int row2)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int temp = matrix[row1, j]; // Сохранение элемента первой строки
                matrix[row1, j] = matrix[row2, j]; // Перемещение элемента второй строки
                matrix[row2, j] = temp; // Восстановление элемента первой строки
            }
        }
    }
}
