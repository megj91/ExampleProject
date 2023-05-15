using System.Collections.Generic;
using System.IO;
using UnityEngine;
public static class PlayerSessionData
{
    static string fileName = Application.persistentDataPath + "/PlayerInventory.json";
    public static float Moneyamount { get; private set; }
    public static List<string> OwnedClothes = new();
    public static void SetNewMoneyAmount(float _amount)
    {
        Moneyamount = _amount;
    }

    public static void SubstractMoney(float _amount)
    {
        Moneyamount -= _amount;
    }

    public static void AddnewClothesToInventory(string _clothesNames)
    {
        if (!OwnedClothes.Contains(_clothesNames))
        {
            OwnedClothes.Add(_clothesNames);
        }
    }
    public static void SavePlayerData()
    {
        StorableData m_toSave = new(OwnedClothes, Moneyamount);
        string m_Json = JsonUtility.ToJson(m_toSave, true);

        File.WriteAllText(fileName, m_Json);

        Debug.Log(fileName );
    }
    public static void LoadPlayerData()
    {
        
        if (File.Exists(fileName))
        {
            string m_Json = File.ReadAllText(fileName);
            StorableData m_loadedData = JsonUtility.FromJson<StorableData>(m_Json);
            OwnedClothes = m_loadedData.WearableIDNameDataList;
            Moneyamount = m_loadedData.Money;
        }

    }
}
