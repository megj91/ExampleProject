
using UnityEngine;

public interface ISpriteManager
{
    void PopulateSprites(WearableData wearableData);
    Sprite GetSprite(PlayerOrientation playerOrientation, int index);
    int GetSpriteCount(PlayerOrientation playerOrientation);
}
