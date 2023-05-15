using UnityEngine;

public class UINpcShopController : MonoBehaviour
{
    
    [SerializeField] private UINpcShopView  ShopView;
    private void OnEnable()
    {
        EventsHolder.ON_NPC_STORE_INTERACTION += OnInteractionTriggered;
    }
    private void OnDisable()
    {
        EventsHolder.ON_NPC_STORE_INTERACTION -= OnInteractionTriggered;
    }
    private void OnInteractionTriggered(System.Collections.Generic.List<WearableSetScriptable> _listToPrint)
    {
        ShopView.gameObject.SetActive(true);
        ShopView.Init(_listToPrint);
    }

}

