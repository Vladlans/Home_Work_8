//Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Console.Clear();

int InputNumber(string message)
{
    while (true)
    {
        Console.Write(message);
        bool result = int.TryParse(Console.ReadLine() ?? "0", out int number);
        if (!result)
        {
            Console.WriteLine($"Ввод некорректный! Попробуйте ещё раз.");
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

int[,] MultiplicationOfTwoMatrices(int[,] a, int[,] b)
{
    int ma = a.GetLength(0);
    int mb = b.GetLength(0);
    int nb = b.GetLength(1);

    int[,] multiMatrix = new int[ma, nb];

    for (int i = 0; i < ma; i++)
    {
        for (int j = 0; j < nb; j++)
        {
            for (int z = 0; z < mb; z++)
            {
                multiMatrix[i, j] += a[i, z] * b[z, j];
            }
        }
    }
    return multiMatrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}  ");
        }
        Console.WriteLine();
    }
}

int m = InputNumber("Задайте количество строк 1-го массива:    ");
int n = InputNumber("Задайте количество столбцов 1-го массива: ");
int[,] matrix1 = GetMatrix(m, n);
Console.WriteLine();
int k = InputNumber("Задайте количество строк 2-го массива:    ");
int l = InputNumber("Задайте количество столбцов 2-го массива: ");
int[,] matrix2 = GetMatrix(k, l);
Console.WriteLine();
PrintMatrix(matrix1);
Console.WriteLine();
PrintMatrix(matrix2);
Console.WriteLine();
if (n != k)
    Console.WriteLine($"Перемножение невозможно. ");
else
    PrintMatrix(MultiplicationOfTwoMatrices(matrix1, matrix2));
Console.WriteLine();
