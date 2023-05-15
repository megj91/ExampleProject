using System;

[Serializable]
public class ItemStored
{
    public string itemInventoryId;
    public string itemId;
    public string itemName;
    public ItemType itemType;
    public float ammount;
    public int equipedSocket=-1;
}
