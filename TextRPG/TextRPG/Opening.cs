using System;
using System.Text;
using System.Threading;

class Opening
{
public void Show()
{
Console.OutputEncoding = Encoding.UTF8;

    string[] lines = new string[]
    {
        "████████╗███████╗██╗  ██╗████████╗    ██████╗ ██████╗  ██████╗ ",
        "╚══██╔══╝██╔════╝╚██╗██╔╝╚══██╔══╝    ██╔══██╗██╔══██╗██╔════╝ ",
        "   ██║   █████╗   ╚███╔╝    ██║       ██████╔╝██████╔╝██║  ███╗",
        "   ██║   ██╔══╝   ██╔██╗    ██║       ██╔══██╗██╔═══╝ ██║   ██║",
        "   ██║   ███████╗██╔╝ ██╗   ██║       ██║  ██║██║     ╚██████╔╝",
        "   ╚═╝   ╚══════╝╚═╝  ╚═╝   ╚═╝       ╚═╝  ╚═╝╚═╝      ╚═════╝ "
    };


    string[] colors = new string[]
    {
        "\u001b[38;2;34;87;122m",   // #22577A
        "\u001b[38;2;56;163;165m",  // #38A3A5
        "\u001b[38;2;87;204;153m",  // #57CC99
        "\u001b[38;2;128;237;153m", // #80ED99
        "\u001b[38;2;153;255;237m", // #99FFED
        "\u001b[38;2;255;255;255m"  // #FFFFFF
    };

    int consoleWidth = Console.WindowWidth;
    int consoleHeight = Console.WindowHeight;

    bool keyPressed = false;
    int frame = 0;

    while (!keyPressed)
    {
        Console.Clear();

        int startY = (consoleHeight - lines.Length) / 2;
        int startX = (consoleWidth - lines[0].Length) / 2;

        // 사이버펑크 테두리 이펙트
        string[] glow = new string[] { "⚡", "🞄", "◉", "♦", "░" };


        // 아래쪽 장식
        Console.SetCursorPosition(startX - 4, startY + lines.Length + 1);
        Console.Write($"\u001b[38;2;255;0;150m▶ 아무 키나 눌러주세요...\u001b[0m");

        // 아트 출력
        for (int i = 0; i < lines.Length; i++)
        {
            // 윗쪽 장식
            string effect = glow[i % glow.Length];
            Console.SetCursorPosition(startX - 4, startY - 2);
            Console.Write($"\u001b[38;2;255;0;255m{effect}{effect}{effect} LOADING {effect}{effect}{effect}\u001b[0m");
           
            Thread.Sleep(300);
            Console.SetCursorPosition(startX, startY + i);
            Console.Write($"{colors[i]}{lines[i]}\u001b[0m");
        }

        // 아래쪽 장식
        Console.SetCursorPosition(startX - 4, startY + lines.Length + 1);
        Console.Write($"\u001b[38;2;255;0;150m▶ 아무 키나 눌러주세요...\u001b[0m");

        // 키 입력 대기
        if (Console.KeyAvailable)
        {
            Console.ReadKey(true);
            keyPressed = true;
        }


        Thread.Sleep(2000); // 애니메이션 속도

    }

    Console.Clear();
    Console.WriteLine("\u001b[38;2;0;255;150m✅ 시작합니다! 시스템 부팅 중...\u001b[0m");
}
}