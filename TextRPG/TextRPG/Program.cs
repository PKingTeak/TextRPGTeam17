using System;
using System.Drawing;
using TextRPG.QuestSystem;
using TextRPG.Scene;
using TextRPG.Unit.Child;



class Program
{

    static void Main(string[] args)
    {     
    string[] lines = new string[]
    {
        "████████╗███████╗██╗  ██╗████████╗    ██████╗ ██████╗  ██████╗ ",
        "╚══██╔══╝██╔════╝╚██╗██╔╝╚══██╔══╝    ██╔══██╗██╔══██╗██╔════╝ ",
        "   ██║   █████╗   ╚███╔╝    ██║       ██████╔╝██████╔╝██║  ███╗",
        "   ██║   ██╔══╝   ██╔██╗    ██║       ██╔══██╗██╔═══╝ ██║   ██║",
        "   ██║   ███████╗██╔╝ ██╗   ██║       ██║  ██║██║     ╚██████╔╝",
        "   ╚═╝   ╚══════╝╚═╝  ╚═╝   ╚═╝       ╚═╝  ╚═╝╚═╝      ╚═════╝ "
    };

    for (int i = 0; i < lines.Length; i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {
            // R, G, B 값을 점점 증가시키는 그라데이션
            int red = 255 * j / lines[i].Length;
            int green = 100;
            int blue = 255 - (255 * j / lines[i].Length);

            Console.ForegroundColor = ClosestConsoleColor(red, green, blue);
            Console.Write(lines[i][j]);
        }
        Console.WriteLine();
    }

    Console.ResetColor();
}

// 256 RGB 색상 -> ConsoleColor에 가장 가까운 값 계산
static ConsoleColor ClosestConsoleColor(int r, int g, int b)
{
    ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
    ConsoleColor bestColor = 0;
    double bestDiff = double.MaxValue;

    foreach (var cc in colors)
    {
        var c = System.Drawing.Color.FromName(cc.ToString());
        double diff = Math.Pow(c.R - r, 2) + Math.Pow(c.G - g, 2) + Math.Pow(c.B - b, 2);

        if (diff < bestDiff)
        {
            bestDiff = diff;
            bestColor = cc;
        }
    }

    return bestColor;
    }
}
