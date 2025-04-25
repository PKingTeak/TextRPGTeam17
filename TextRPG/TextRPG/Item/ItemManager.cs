using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Unit.Child;

public class ItemManager
{
    public List<Item> Items { get; private set; } = new List<Item>();
    Player player;

    // 현재 장착 중인 무기/방어구 저장 변수
    private Item? equippedWeapon = null;
    private Item? equippedArmor = null;

    public ItemManager(Player player)
    {
        this.player = player;
        Items.Add(new Item("불꽃의 검", Item.ItemType.Weapon, 15, "불 속성을 띤 강력한 검.", 1000));
        Items.Add(new Item("전투 도끼", Item.ItemType.Weapon, 12, "묵직한 일격을 가하는 도끼.", 850));
        Items.Add(new Item("엘프의 활", Item.ItemType.Weapon, 11, "정확도가 높은 마법 활.", 900));
        Items.Add(new Item("철 투구", Item.ItemType.Armor, 5, "머리를 보호하는 튼튼한 철 투구.", 400));
        Items.Add(new Item("용의 갑옷", Item.ItemType.Armor, 20, "전설 속 용의 비늘로 만든 방어구.", 2000));
    }

    /// <summary>
    /// 인덱스를 통해 아이템 장착
    /// </summary>
    /// <param name="index"></param>
    public void EquipItemByIndex(int index)
    {
        if (index < 0 || index >= Items.Count)
        {
            Console.WriteLine("잘못된 인덱스입니다.");
            return;
        }

        var item = Items[index];

        if (item.IsEquipped)
            DeEquipmentItem(item);
        else
            EquipmentItem(item);
    }

    // 아이템 장착
    private void EquipmentItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.Weapon:
                if (equippedWeapon != null)
                {
                    // 장착된 무기가 있다면 해제
                    equippedWeapon.ChangeEquipStatus(false);
                    player.DequimentItem(equippedWeapon);
                }
                
                // 현재 장착 무기 변경
                equippedWeapon = item;
                break;

            case Item.ItemType.Armor:
                if (equippedArmor != null)
                {
                    // 장착된 방어구가 있다면 해제
                    equippedArmor.ChangeEquipStatus(false);
                    player.DequimentItem(equippedArmor);
                }   

                // 현재 장착 방어구 변경
                equippedArmor = item;
                break;
        }
        Console.WriteLine($"{item.Name}을(를) 장착");

        // 플레이어 아이템 착용
        player.EquimentItem(item);
        item.ChangeEquipStatus(true);
    }

    // 아이템 장착해제
    private void DeEquipmentItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.Weapon:
                if (item == equippedWeapon)
                    equippedWeapon = null;
                break;

            case Item.ItemType.Armor:
                if (equippedArmor == item)
                    equippedArmor = null;
                break;
        }

        Console.WriteLine($"{item.Name}을(를) 장착 해제");
        player.DequimentItem(item);
        item.ChangeEquipStatus(false);
    }
    public void ShowEquippedItems()
    {
        Console.WriteLine("현재 장착 중인 아이템");
        Console.WriteLine($" - 무기: {(equippedWeapon != null ? equippedWeapon.Name : "없음")}");
        Console.WriteLine($" - 방어구: {(equippedArmor != null ? equippedArmor.Name : "없음")}");
    }

    public void BuyItem(Item item)
    {
        if (!item.IsOwned)
        {
            item.ChangeOwnership(true);
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

    // 랜덤 아이템 반환
    public Item GetRandomItem()
    {
        Random rand = new Random();

        return Items[rand.Next(0, Items.Count)];
    }
}