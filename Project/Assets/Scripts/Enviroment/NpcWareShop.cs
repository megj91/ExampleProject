using UnityEngine;
using System.Collections.Generic;   
public class NpcWareShop : MonoBehaviour , IExecuteActionOnTrigger
{
    [SerializeField] private List<WearableSetScriptable> AvailableClothes;
   
    public void OnTriggerExecution()
    {
        EventsHolder.ON_NPC_STORE_INTERACTION?.Invoke(AvailableClothes);
    }
    
}
