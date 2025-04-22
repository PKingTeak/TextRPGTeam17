using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Item
{
    public enum ItemType
    {
        WeaPon,
        Armor
    }

    public string Name { get; set; }
    public Dictionary<ItemType, int> Stats { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public bool IsOwned { get; private set; }
    public bool IsEquipped { get; private set; }

    public Item(string name, Dictionary<ItemType, int> stats, string description, int price)
    {
        Name = name;
        Stats = stats;
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