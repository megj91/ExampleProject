using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantsSpriteManager : SpriteManager, ISpriteManager
{
    public void PopulateSprites(WearableData wearableData)
    {
        UpSprites = wearableData.UpSprites;
        DownSprites = wearableData.DownSprites;
        LeftSprites = wearableData.LeftSprites;
        RightSprites = wearableData.RightSprites;
    }

    public Sprite GetSprite(PlayerOrientation playerOrientation, int index)
    {
        return playerOrientation switch
        {
            PlayerOrientation.Up => index >= UpSprites.Count ? UpSprites[0] : UpSprites[index],
            PlayerOrientation.Down => index >= DownSprites.Count ? DownSprites[0] : DownSprites[index],
            PlayerOrientation.Idle => index >= DownSprites.Count ? DownSprites[0] : DownSprites[index],
            PlayerOrientation.Left => index >= LeftSprites.Count ? LeftSprites[0] : LeftSprites[index],
            PlayerOrientation.Right => index >= RightSprites.Count ? RightSprites[0] : RightSprites[index],
            _ => null,
        };
    }
    public int GetSpriteCount(PlayerOrientation playerOrientation)
    {
        return playerOrientation switch
        {
            PlayerOrientation.Up => UpSprites.Count,
            PlayerOrientation.Down => DownSprites.Count,
            PlayerOrientation.Idle => DownSprites.Count,
            PlayerOrientation.Left => LeftSprites.Count,
            PlayerOrientation.Right => RightSprites.Count,
            _ => -1,
        };
    }
}
