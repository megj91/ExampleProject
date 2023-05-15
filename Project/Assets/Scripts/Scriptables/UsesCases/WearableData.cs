using System.Collections.Generic;
using UnityEngine;
using System;
 
[Serializable]
public struct WearableData :IItem
{
    [Header("Data")]
    [Space]
    public string WearableName;
    public string WearableID;
    public ItemType ItemType;
    public float WearablePrice;


    [Header("Visuals")]
    [Space]
    public Sprite WerableSmallImage;
    public List<Sprite> UpSprites;
    public List<Sprite> DownSprites;
    public List<Sprite> LeftSprites;
    public List<Sprite> RightSprites;


    

    public T getItemData<T>()
    {
        return (T)Convert.ChangeType(this, typeof(T));
    }

    public string GetItemId()
    {
        return WearableID;
    }

    public string getItemName()
    {
        return WearableName;
    }

    public Sprite getItemThumbnail()
    {
        return WerableSmallImage;
    }

    public ItemType getItemType()
    {
        return ItemType;
    }

 
}
