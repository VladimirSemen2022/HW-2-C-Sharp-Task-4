//Создайте приложение, которое производит операции над матрицами:
// - Умножение матрицы на число;
// - Сложение матриц;
// - Произведение матриц.

using System;

namespace HW_2_C_Sharp_Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Добавление матрицы
            int[,] CreateArray()
            {
                Console.WriteLine("Input values of rows and columns for creating a matrix:");
                Console.Write("Input a number of matrix`s rows - ");
                int arrX = int.Parse(Console.ReadLine());
                Console.Write("Input a number of matrix`s columns - ");
                int arrY = int.Parse(Console.ReadLine());
                int [,] array = new int[arrX, arrY];
                return array;
            }
            //Заполнение ячеек матрицы значениями
            void FillArray (int [,] array)
            {
                Console.WriteLine("Enter numbers into cells of the matrix");
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"[{i}, {j}] - ");
                        array[i, j] = int.Parse(Console.ReadLine());
                    }
                }
            }
            //Показ значений ячеек матрицы
            void ShowArray(int[,] array)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"{array[i, j]}  ");

                    }
                    Console.Write("\n");
                }
            }

            int[,] matrix, matrix1, matrix2;
            Console.WriteLine("Input a number of position that you want to do with the matrix:\n1. Multiply by number;\n2. Add two matrices;\n3. Multiply two matrices.\n") ;
            char key = Convert.ToChar(Console.ReadKey().Key);
            if (key == '1')
            {
                Console.Clear();
                Console.Write("Enter a number by which the matrix will be multiplied - ");
                int num = int.Parse(Console.ReadLine());
                matrix1 = CreateArray();
                matrix2 = (int[,])matrix1.Clone();
                Console.Write("Enter a number by which the matrix will be multiplied - ");
                FillArray(matrix1);
                for (int i = 0; i < matrix2.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                        matrix2[i, j] = matrix1[i, j] * num;
                }
                Console.Clear();
                Console.WriteLine("Your matrix:");
                ShowArray(matrix1);
                Console.WriteLine($"New matrix after multiply by number {num}:");
                ShowArray(matrix2);
            }
            else if (key == '2')
            {
                Console.Clear();
                Console.WriteLine("Input values of rows and columns for create and addition of two matrices:");
                matrix1 = CreateArray();
                matrix2 = (int[,])matrix1.Clone();
                matrix = (int[,])matrix1.Clone();
                Console.WriteLine("Input data into first matrix:");
                FillArray(matrix1);
                Console.WriteLine("Input data into second matrix:");
                FillArray(matrix2);
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                        matrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
                Console.Clear();
                Console.WriteLine("Your first matrix:");
                ShowArray(matrix1);
                Console.WriteLine("Your second matrix:");
                ShowArray(matrix2);
                Console.WriteLine("New matrix as summ first matrix and second matrix:");
                ShowArray(matrix);
            }
            else if (key == '3')
            {
                Console.Clear();
                Console.WriteLine("Input values of rows and columns for create and multiply of two matrices:");
                Console.WriteLine("Rule: amount of columns first matrix must be equal amount of rows second matrix\n");
                matrix1 = CreateArray();
                matrix2 = CreateArray();
                if (matrix1[0, 1] == matrix2[0, 0])
                {
                    matrix = new int [matrix1.GetLength(0), matrix2.GetLength(1)];
                    Console.WriteLine("Input data in the first matrix:");
                    FillArray(matrix1);
                    Console.WriteLine("Input data in the second matrix:");
                    FillArray(matrix2);
                    for (int i = 0; i < matrix1.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix2.GetLength(1); j++)
                        {
                            for (int k = 0; k < matrix1.GetLength(1) ; k++)
                                matrix[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Your first matrix:");
                    ShowArray(matrix1);
                    Console.WriteLine("Your second matrix:");
                    ShowArray(matrix2);
                    Console.WriteLine("New matrix as multiplication first matrix and second matrix:");
                    ShowArray(matrix);
                }
                else
                    Console.WriteLine("Ground rule not met!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You chose wrong number");
            }
        }
    }
}
