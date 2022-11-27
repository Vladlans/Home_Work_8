//Напишите программу, которая заполнит спирально массив 4 на 4.
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
            matrix[i, j] = -1;
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
            string result = String.Format("{0:d2}", matrix[i, j]);
            Console.Write($"{result} ");
        }
        Console.WriteLine();
    }
}

int[,] Spiral(int row, int col)
{
    int[,] spiralArray = GetMatrix(row, col);
    int num = 1;

    int vert = 0;  // номер ряда
    int hor = 0;  // номер колонки

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {

            for (j = hor; j < col; j++)     // верхний ряд 
            {
                spiralArray[vert, j] = num;
                num++;
            }
            vert++;     // номер ряда увеличился - спустились на 1

            for (i = vert; i < row; i++)       // правый столбец
            {
                spiralArray[i, col - 1] = num;
                num++;
            }
            col--;      // по колонкам сдвиг на 1 влево

            for (j = col - 1; j >= vert - 1; j--)  // нижний ряд
            {
                spiralArray[row - 1, j] = num;
                num++;
            }
            row--;      // номер ряда уменьшился - поднялись на 1

            for (i = row - 1; i > hor; i--)      // левый столбец
            {
                spiralArray[i, vert - 1] = num;
                num++;
            }
            hor++;  // по колонкам сдвиг вправо на 1
        }
    }
    return spiralArray;
}

int m = InputNumber("Задайте размерность матрицы:  ");

int[,] spiral = Spiral(m, m);
Console.WriteLine();
PrintMatrix(spiral);
Console.WriteLine();
