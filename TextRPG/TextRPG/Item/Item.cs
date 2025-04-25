using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Unit.Child;

public class Item
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Potion
    }

    public string Name { get; set; }
    public ItemType itemType { get; set; }
    public int Value { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public bool IsOwned { get; private set; }
    public bool IsEquipped { get; private set; }
    public int Count { get; private set; }
    public Item(string name, ItemType itemType, int value, string description, int price)
    {
        Name = name;
        this.itemType = itemType;
        Value = value;
        Description = description;
        Price = price;
        IsOwned = false;
        IsEquipped = false;
        Count = 0;
    }

    // 포션 아이템 구매 및 획득
    public void GetItem()
    {
        if (itemType == ItemType.Potion)
            Count++;
    }

    // 포션 아이템 소비
    public void ConsumeItem()
    {
        if(itemType == ItemType.Potion)
        Count--;

        if (Count < 0)
            Count = 0;
    }

    public void ChangeOwnership(bool owned)
    {
        IsOwned = owned;
    }
    public void ChangeEquipStatus(bool equipped)
    {
        IsEquipped = equipped;
    }

    public override string ToString()
    {
        if (itemType != ItemType.Potion)
            return $"{Name} - {Description} / Price: {Price} / Owned: {IsOwned} / Equipped: {IsEquipped}";
        else
            return $"{Name} - {Description} / Price: {Price} / OwnedCount: {Count} ";
    }
}