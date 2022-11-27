//Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Console.Clear();

int InputNumber(string message)
{
    while (true)
    {
        Console.Write(message);
        bool result = int.TryParse(Console.ReadLine() ?? "0", out int number);
        if (!result)
        {
            Console.WriteLine($"Неккоректный ввод! Попробуйте ещё раз.");
            Thread.Sleep(1500);
            continue;
        }
        return number;
    }
}

int[,] GetMatrix(int m, int n)
{
    int[,] matrix = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            matrix[i, j] = new Random().Next(0, 10);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}   ");
        }
        Console.WriteLine();
    }
}

void DescendingElementsOfTheRows(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int maxPosition = j;
            for (int k = j + 1; k < matrix.GetLength(1); k++)
            {
                if (matrix[i,k] > matrix[i,maxPosition]) maxPosition = k;
            }
            int temp = matrix[i,j];
            matrix[i,j] = matrix[i,maxPosition];
            matrix[i,maxPosition] = temp;
        }
    }
}

int m = InputNumber("Задайте количество строк массива:    ");
int n = InputNumber("Задайте количество столбцов массива: ");
int[,] matrix = GetMatrix(m, n);
Console.WriteLine();
PrintMatrix(GetMatrix(m, n));
Console.WriteLine();
DescendingElementsOfTheRows(matrix);
PrintMatrix(matrix);
