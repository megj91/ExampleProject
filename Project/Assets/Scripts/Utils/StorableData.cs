using System.Collections.Generic;
using System;

[Serializable]
public class StorableData
{
    public List<string> WearableIDNameDataList;
    public float Money;
    public StorableData(List<string> _toSave, float _money)
    {
        WearableIDNameDataList = _toSave;
        Money = _money;
    }
}