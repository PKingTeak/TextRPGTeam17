using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ItemManager
{
    public List<Item> Items { get; private set; } = new List<Item>();


    public ItemManager()
    {
        // 테스트용 아이템 추가
        Items.Add(new Item(
            name: "불꽃의 검",
            stats: new Dictionary<Item.ItemType, int> { { Item.ItemType.WeaPon, 15 } },
            description: "불 속성을 띤 강력한 검.",
            price: 1000
        ));

        Items.Add(new Item(
            name: "전투 도끼",
            stats: new Dictionary<Item.ItemType, int> { { Item.ItemType.WeaPon, 12 } },
            description: "묵직한 일격을 가하는 도끼.",
            price: 850
        ));

        Items.Add(new Item(
            name: "엘프의 활",
            stats: new Dictionary<Item.ItemType, int> { { Item.ItemType.WeaPon, 11 } },
            description: "정확도가 높은 마법 활.",
            price: 900
        ));

        Items.Add(new Item(
            name: "철 투구",
            stats: new Dictionary<Item.ItemType, int> { { Item.ItemType.Armor, 5 } },
            description: "머리를 보호하는 튼튼한 철 투구.",
            price: 400
        ));

        Items.Add(new Item(
            name: "용의 갑옷",
            stats: new Dictionary<Item.ItemType, int> { { Item.ItemType.Armor, 20 } },
            description: "전설 속 용의 비늘로 만든 방어구.",
            price: 2000
        ));
    }


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

    public string ShowItems(int idx)
    {
        return Items[idx].ToString();
    }


}