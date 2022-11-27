//Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Console.Clear();

int[] MixedArray(int[] arr)
{
    Random r = new Random();
    for (int i = 89; i >= 1; i--)
    {
        int j = r.Next(i + 1);
        int temp = arr[j];
        arr[j] = arr[i];
        arr[i] = temp;
    }
    return arr;
}

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

int[,,] GetMatrix3D(int l, int m, int n)
{
    int[] inOrderArray = Enumerable.Range(10, 90).ToArray();
    int[,,] matrix3D = new int[l, m, n];
    for (int i = 0; i < l; i++)
    {
        for (int j = 0; j < m; j++)
        {
            for (int k = 0; k < n; k++)
            {
                for (int p = 0; p < l * m * n; p++)
                {
                    matrix3D[i, j, k] = MixedArray(inOrderArray)[p];
                    MixedArray(inOrderArray)[p]++;
                }
            }
        }
    }
    return matrix3D;
}

void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                Console.Write($"{matrix[i, j, k]}({i}, {j}, {k})  ");
            }
            Console.WriteLine();
        }
    }
}

int l = InputNumber($"Введите размер 1:  ");
int m = InputNumber($"Введите размер 2:  ");
int n = InputNumber($"Введите размер 3:  ");
Console.WriteLine();
int[,,] array3D = GetMatrix3D(l, m, n);
PrintMatrix(array3D);
Console.WriteLine();
