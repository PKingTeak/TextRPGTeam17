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
        Armor
    }

    public string Name { get; set; }
    public ItemType itemType { get; set;}
    public int Value {get; set;}
    public string Description { get; set; }
    public int Price { get; set; }
    public bool IsOwned { get; private set; }
    public bool IsEquipped { get; private set; }

    public Item(string name, ItemType itemType, int value ,string description, int price)
    {
        Name = name;
        this.itemType = itemType;
        Value = value;
        Description = description;
        Price = price;
        IsOwned = false;
        IsEquipped = false;
    }

    public void ChangeOwnership(bool owned)
    {
        IsOwned = owned;
    }

    public Dictionary<ItemType, int> state { get; set; }
    public void ChangeEquipStatus(bool equipped)
    {
        IsEquipped = equipped;
    }

    public override string ToString()
    {
        return $"{Name} - {Description} / Price: {Price} / Owned: {IsOwned} / Equipped: {IsEquipped}";
    }
}