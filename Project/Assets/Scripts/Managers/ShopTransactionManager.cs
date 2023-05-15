using System.Collections.Generic;
public static class ShopTransactionManager
{
    public static       Dictionary<string, WearableData> AllStoreData = new();
    public static void AddRawDataToStore(List<WearableData> _newData)
    {
        for (int i = 0; i < _newData.Count; i++)
        {
            var m_data = _newData[i];
            if (!AllStoreData.ContainsKey(m_data.WearableName))
                AllStoreData.Add(m_data.WearableName, m_data);
        }
        
    }
    public static void WearPlayer(string _indexName, ItemType _type)
    {
        WearableData m_wereableData = GetWaearableData(_indexName);
        if (_type == ItemType.SHIRT)
        {
            EventsHolder.ON_WEAR_SHIRTS?.Invoke(m_wereableData);
        }
        else
        {
            EventsHolder.ON_WEAR_PANTS?.Invoke(m_wereableData);
        }
    }

    public static void SetTransactionValues(string _setName, float _value, ItemType _type)
    {
        WearableData m_wereableData = GetWaearableData(_setName);
        if (VerifyPlayerMoney(_value))
        {
            if (_type == ItemType.SHIRT)
            {
                EventsHolder.ON_BUY_SHIRTS?.Invoke(m_wereableData);
            }
            else
            {
                EventsHolder.ON_BUY_PANTS?.Invoke(m_wereableData);
            }

            PlayerSessionData.SubstractMoney(_value);
            EventsHolder.ON_BUY?.Invoke(PlayerSessionData.Moneyamount);
        }
    }
    public static WearableData GetWaearableData(string _itemName)
    {
        return AllStoreData[_itemName];
    }

    private  static bool  VerifyPlayerMoney(float _setCost)
    {
        float m_currentMoney = PlayerSessionData.Moneyamount;
        float m_totalBuyAmount = m_currentMoney - _setCost;
        return (m_totalBuyAmount > 0);
    }
}