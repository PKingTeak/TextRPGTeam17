using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ItemManager
{
    public List<Item> Items { get; private set; } = new List<Item>();

    // 현재 장착 중인 무기/방어구 저장 변수
    private Item equippedWeapon = null;
    private Item equippedArmor = null;

    public ItemManager()
    {
        Items.Add(new Item("불꽃의 검", new Dictionary<Item.ItemType, int> { { Item.ItemType.WeaPon, 15 } }, "불 속성을 띤 강력한 검.", 1000));
        Items.Add(new Item("전투 도끼", new Dictionary<Item.ItemType, int> { { Item.ItemType.WeaPon, 12 } }, "묵직한 일격을 가하는 도끼.", 850));
        Items.Add(new Item("엘프의 활", new Dictionary<Item.ItemType, int> { { Item.ItemType.WeaPon, 11 } }, "정확도가 높은 마법 활.", 900));
        Items.Add(new Item("철 투구", new Dictionary<Item.ItemType, int> { { Item.ItemType.Armor, 5 } }, "머리를 보호하는 튼튼한 철 투구.", 400));
        Items.Add(new Item("용의 갑옷", new Dictionary<Item.ItemType, int> { { Item.ItemType.Armor, 20 } }, "전설 속 용의 비늘로 만든 방어구.", 2000));
    }

    public void EquipItemByIndex(int index)
    {
        if (index < 0 || index >= Items.Count)
        {
            Console.WriteLine("잘못된 인덱스입니다.");
            return;
        }

        var item = Items[index];

        if (!item.IsOwned)
        {
            Console.WriteLine($"{item.Name}은(는) 보유 중이지 않습니다.");
            return;
        }

        var itemType = item.Stats.Keys.First();

        if (item.IsEquipped)
        {
            Console.WriteLine($"{item.Name}은(는) 이미 장착 중입니다.");
            return;
        }

        if (itemType == Item.ItemType.WeaPon)
        {
            if (equippedWeapon != null)
            {
                equippedWeapon.ChangeEquipStatus(false);
                Console.WriteLine($"기존 무기 {equippedWeapon.Name} 장착 해제.");
            }

            equippedWeapon = item;
        }
        else if (itemType == Item.ItemType.Armor)
        {
            if (equippedArmor != null)
            {
                equippedArmor.ChangeEquipStatus(false);
                Console.WriteLine($"기존 방어구 {equippedArmor.Name} 장착 해제.");
            }

            equippedArmor = item;
        }

        item.ChangeEquipStatus(true);
        Console.WriteLine($"{item.Name} 장착 완료!");
    }

    public void ShowEquippedItems()
    {
        Console.WriteLine("🧤 현재 장착 중인 아이템:");
        Console.WriteLine($"무기: {(equippedWeapon != null ? equippedWeapon.Name : "없음")}");
        Console.WriteLine($"방어구: {(equippedArmor != null ? equippedArmor.Name : "없음")}");
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
            if (item == equippedWeapon) equippedWeapon = null;
            if (item == equippedArmor) equippedArmor = null;

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

    public string ShowItems(int idx)
    {
        return Items[idx].ToString();
    }
}