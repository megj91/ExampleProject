using System.Collections.Generic;
using UnityEngine;

public class WearableDataInjection : MonoBehaviour
{
    [SerializeField] private List<WearableSetScriptable> wearablesDataToAdd;
    void Awake()
    {
        List<WearableData> m_DataListToadd = new();
        for (int i = 0; i < wearablesDataToAdd.Count; i++)
        {
            var m_data = wearablesDataToAdd[i];
            m_DataListToadd.Add(m_data.WearablePants);
            m_DataListToadd.Add(m_data.WearableShirt);
        }
        ShopTransactionManager.AddRawDataToStore(m_DataListToadd);
    }
}
