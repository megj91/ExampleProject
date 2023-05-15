using UnityEngine;

public class PlayerInventoryHolder : MonoBehaviour
{
    [SerializeField] private float PlayerMoney;
    private void Awake()
    {
        PlayerSessionData.LoadPlayerData();
    }
    private void Start()
    {
        PlayerSessionData.SetNewMoneyAmount(PlayerMoney);
    }

    private void OnEnable()
    {
        EventsHolder.ON_BUY_PANTS += OnBuy;
        EventsHolder.ON_BUY_SHIRTS += OnBuy;
    }
    private void OnDisable()
    {
        EventsHolder.ON_BUY_PANTS -= OnBuy;
        EventsHolder.ON_BUY_SHIRTS -= OnBuy;
    }


    private void OnBuy(WearableData _data)
    {
        PlayerSessionData.AddnewClothesToInventory(_data.WearableName);
        PlayerSessionData.SavePlayerData();
    }
}
