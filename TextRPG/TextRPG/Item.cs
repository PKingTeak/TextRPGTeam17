using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, int> Stats { get; set; } = new Dictionary<string, int>();
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsOwned { get; private set; } = false;
        public bool IsEquipped { get; private set; } = false;

        public Item(string name, string type, Dictionary<string, int> stats, string description, int price)
        {
            Name = name;
            Type = type;
            Stats = stats;
            Description = description;
            Price = price;
        }

        // 소지 여부 변경
        public void SetOwnership(bool own)
        {
            IsOwned = own;

            if (!own)
            {
                IsEquipped = false;
            }
        }

        // 장착 여부 변경
        public void SetEquipped(bool equip)
        {
            if (!IsOwned)
            {
                Console.WriteLine($"{Name} 아이템은 소지하고 있지 않아서 장착할 수 없습니다.");
                return;
            }

            IsEquipped = equip;
        }

        // 아이템 정보 출력
        public void PrintInfo()
        {
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"타입: {Type}");
            Console.WriteLine($"설명: {Description}");
            Console.WriteLine($"가격: {Price} 골드");
            Console.WriteLine("능력치:");
            foreach (var stat in Stats)
            {
                Console.WriteLine($" - {stat.Key}: {stat.Value}");
            }
            Console.WriteLine($"소지 여부: {(IsOwned ? "있음" : "없음")}");
            Console.WriteLine($"장착 여부: {(IsEquipped ? "장착 중" : "미장착")}");
        }
    }
}