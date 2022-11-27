//Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
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

void PrintArray(int[] array)
{
    Console.WriteLine($"Суммы элементов в строках:");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]}   ");
    }
    Console.WriteLine();
}

int[] SumElementsOfTheRows(int[,] matrix)
{
    int[] sumOfRows = new int[matrix.GetLength(0)];
    int sum = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sum = 0;

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum = sum + matrix[i, j];
        }
        sumOfRows[i] = sum;
    }
    return sumOfRows;
}

void RowWithMinimalSum(int[] array)
{
    int minIndex = 0;
    int minElem = array[0];
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] < minElem)
        {
            minElem = array[i];
            minIndex = i;
        }
    }
    Console.Write($"Номер строки с наименьшей суммой элементов: {minIndex + 1}.");
}

int m = InputNumber("Задайте количество строк массива:    ");
int n = InputNumber("Задайте количество столбцов массива: ");
int[,] matrix = GetMatrix(m, n);
Console.WriteLine();
PrintMatrix(matrix);
Console.WriteLine();
int[] sum = SumElementsOfTheRows(matrix);
PrintArray(sum);
RowWithMinimalSum(sum);
Console.WriteLine();
