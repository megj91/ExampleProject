
using UnityEngine;

public enum ItemType
{
    SHIRT,
    PANTS
}

public interface IItem 
{
    T getItemData<T>();
    ItemType getItemType();
    Sprite getItemThumbnail();
    string getItemName();

    string GetItemId();

}
