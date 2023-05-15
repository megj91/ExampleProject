using UnityEngine;


public interface IItemInventory 
{
    void AddItem(float value);
    void InitializeItemValue(IItem newItem);
    bool IsKindOfItem(IItem currItem);
    IItem GetItemData();
    string GetInventoryID();
    Sprite GetItemThumbnail ();
}
