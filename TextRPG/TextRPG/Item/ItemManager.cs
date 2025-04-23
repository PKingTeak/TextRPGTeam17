using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ItemManager
{
    public List<Item> Items { get; private set; } = new List<Item>();

    public void BuyItem(Item item)
    {
        if (!item.IsOwned)
        {
            item.ChangeOwnership(true);
            Items.Add(item);
            Console.WriteLine($"{item.Name} 구매 완료!");
        }
        else
        {
            Console.WriteLine($"{item.Name}은 이미 소지 중입니다.");
        }
    }

    public void SellItem(Item item)
    {
        if (item.IsOwned)
        {
            item.ChangeOwnership(false);
            item.ChangeEquipStatus(false);
            Items.Remove(item);
            Console.WriteLine($"{item.Name} 판매 완료!");
        }
        else
        {
            Console.WriteLine($"{item.Name}은 소지하고 있지 않습니다.");
        }
    }

    public void EquipItem(Item item)
    {
        if (item.IsOwned && !item.IsEquipped)
        {
            item.ChangeEquipStatus(true);
            Console.WriteLine($"{item.Name} 장착 완료!");
        }
        else
        {
            Console.WriteLine($"{item.Name}은 장착할 수 없습니다.");
        }
    }

    public void UnequipItem(Item item)
    {
        if (item.IsEquipped)
        {
            item.ChangeEquipStatus(false);
            Console.WriteLine($"{item.Name} 장착 해제 완료!");
        }
        else
        {
            Console.WriteLine($"{item.Name}은 장착되어 있지 않습니다.");
        }
    }

    public void ShowItems()
    {
        foreach (var item in Items)
        {
            Console.WriteLine(item);
        }
    }


}