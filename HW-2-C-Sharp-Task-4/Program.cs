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
            double[,] CreateArray()
            {
                Console.WriteLine("Input values of rows and columns for creating a matrix:");
                Console.Write("Input a number of matrix`s rows - ");
                int arrX = int.Parse(Console.ReadLine());
                Console.Write("Input a number of matrix`s columns - ");
                int arrY = int.Parse(Console.ReadLine());
                double [,] array = new double[arrX+1, arrY+1];
                array[0, 0] = arrX;
                array[0, 1] = arrY;
                return array;
            }
            //Заполнение ячеек матрицы значениями
            void FillArray (double [,] array)
            {
                Console.WriteLine("Enter numbers into cells of the matrix");
                for (int i = 1; i <= Convert.ToInt16(array[0, 0]); i++)
                {
                    for (int j = 1; j <= Convert.ToInt16(array[0, 1]); j++)
                    {
                        Console.Write($"[{i}, {j}] - ");
                        array[i, j] = double.Parse(Console.ReadLine());
                    }
                }
            }
            //Показ значений ячеек матрицы
            void ShowArray(double[,] array)
            {
                for (int i = 1; i <= Convert.ToInt16(array[0, 0]); i++)
                {
                    for (int j = 1; j <= Convert.ToInt16(array[0, 1]); j++)
                    {
                        Console.Write($"{array[i, j]}  ");

                    }
                    Console.Write("\n");
                }
            }

            double[,] matrix, matrix1, matrix2;
            Console.WriteLine("Choose a number that you want to do with the matrix:\n1. Multiply by number;\n2. Add two matrices;\n3. Multiply two matrices.\n") ;
            char key = Convert.ToChar(Console.ReadKey().Key);
            if (key == '1')
            {
                Console.Clear();
                Console.Write("Enter a number by which the matrix will be multiplied - ");
                double num = double.Parse(Console.ReadLine());
                matrix1 = CreateArray();
                matrix2 = (double[,])matrix1.Clone();
                Console.Write("Enter a number by which the matrix will be multiplied - ");
                FillArray(matrix1);
                for (int i = 1; i <= Convert.ToInt16(matrix2[0, 0]); i++)
                {
                    for (int j = 1; j <= Convert.ToInt16(matrix2[1, 0]); j++)
                        matrix2[i, j] = matrix1[i, j] * num;
                }
                Console.WriteLine("Your matrix:");
                ShowArray(matrix1);
                Console.WriteLine("New matrix:");
                ShowArray(matrix2);
            }
            else if (key == '2')
            {
                Console.Clear();
                Console.WriteLine("Input values of rows and columns for create and addition of two matrices:");
                matrix1 = CreateArray();
                matrix2 = (double[,])matrix1.Clone();
                matrix = (double[,])matrix1.Clone();
                Console.WriteLine("Input data into first matrix:");
                FillArray(matrix1);
                Console.WriteLine("Input data into second matrix:");
                FillArray(matrix2);
                for (int i = 1; i <= Convert.ToInt16(matrix1[0, 0]); i++)
                {
                    for (int j = 1; j <= Convert.ToInt16(matrix1[0, 1]); j++)
                        matrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
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
                Console.WriteLine("Rule: number of columns first matrix must be equal number of rows second matrix");
                matrix1 = CreateArray();
                matrix2 = CreateArray();
                if (matrix1[0, 1] == matrix2[0, 0])
                {
                    matrix = new double [Convert.ToInt16(matrix1[0, 0]+1), Convert.ToInt16(matrix2[0, 1]+1)];
                    Console.WriteLine("Input data in the first matrix:");
                    FillArray(matrix1);
                    Console.WriteLine("Input data in the second matrix:");
                    FillArray(matrix2);
                    for (int i = 1; i <= Convert.ToInt16(matrix1[0, 0]); i++)
                    {
                        for (int j = 1; j <= Convert.ToInt16(matrix2[0, 1]); j++)
                            matrix[i, j] = matrix1[i, j] * matrix2[j, i];
                    }
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
