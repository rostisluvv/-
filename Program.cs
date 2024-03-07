using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Чтение входных данных из файла
        string[] inputLines = File.ReadAllLines("C:\\Users\\user\\source\\repos\\ConsoleApp14\\input.txt");
        string[] dimensions = inputLines[0].Split(' ');
        int N = int.Parse(dimensions[0]);
        int M = int.Parse(dimensions[1]);
        char[,] garden = new char[N, M];

        for (int i = 0; i < N; i++)
        {
            string row = inputLines[i + 1];
            for (int j = 0; j < M; j++)
            {
                garden[i, j] = row[j];
            }
        }

        // Подсчет количества грядок
        int gardenBedsCount = 0;
        bool[,] visited = new bool[N, M];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (garden[i, j] == '#' && !visited[i, j])
                {
                    MarkGarden(garden, visited, N, M, i, j);
                    gardenBedsCount++;
                }
            }
        }

        // Запись результата в выходной файл
        File.WriteAllText("C:\\Users\\user\\source\\repos\\ConsoleApp14\\output.txt", gardenBedsCount.ToString());
    }

    // Метод для пометки грядки и всех смежных с ней квадратов как посещенных
    static void MarkGarden(char[,] garden, bool[,] visited, int N, int M, int i, int j)
    {
        if (i < 0 || j < 0 || i >= N || j >= M || garden[i, j] == '.' || visited[i, j])
        {
            return;
        }

        visited[i, j] = true;
        MarkGarden(garden, visited, N, M, i - 1, j);
        MarkGarden(garden, visited, N, M, i + 1, j);
        MarkGarden(garden, visited, N, M, i, j - 1);
        MarkGarden(garden, visited, N, M, i, j + 1);
    }

}