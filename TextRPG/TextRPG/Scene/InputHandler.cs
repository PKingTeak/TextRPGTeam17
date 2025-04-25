using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG.Scene
{
    public static class InputHandler
    {
        /// <summary>
        /// 사용자에게 선택지를 주고, 그에 대한 입력을 받는 메소드
        /// </summary>
        /// <param name="min">선택지 범위 최소</param>
        /// <param name="max">선택지 범위 최대</param>
        /// <param name="optionTxt">출력할 선택지 텍스트</param>
        /// <param name="comment">입력 대기 텍스트</param>
        /// <returns>입력한 값이 숫자가 아니거나 범위를 벗어나면 -1, 조건에 맞으면 입력한 값 반환</returns>
        public static int ChooseAction(int min, int max, string optionTxt, string comment)
        {
            // 선택지 출력후 콘솔 초기화
            Console.WriteLine(optionTxt);
            Console.WriteLine();
            Console.WriteLine(comment);
            Console.Write(">> ");
            string input = Console.ReadLine();

            int inputNum;
            bool isInt = int.TryParse(input, out inputNum);

            if(!isInt || min > inputNum || inputNum > max)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000);
                inputNum = -1;
            }

            Console.Clear();
            return inputNum;
        }
    }
}
