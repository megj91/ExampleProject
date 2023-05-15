using UnityEngine;

public class UINpcShopView : MonoBehaviour
{
    [SerializeField] private UINpcPrintSetItem      PrefabPrintItem;
    [SerializeField] private RectTransform          ItemHolder;
    [SerializeField] private TMPro.TextMeshProUGUI  PrintMoneyAmount;
    public void Init(System.Collections.Generic.List<WearableSetScriptable> _dataToPrint)
    {
        EventsHolder.ON_DELETE_UI_ITEMS?.Invoke();
        PrintMoneyAmount.text = PlayerSessionData.Moneyamount.ToString();

        for (int i = 0; i < _dataToPrint.Count; i++)
        {
            var m_data = _dataToPrint[i];  
            //-- Thshirts
            UINpcPrintSetItem m_toPrint = Instantiate(PrefabPrintItem, ItemHolder);
            m_toPrint.Init(m_data.WearableShirt.WerableSmallImage, m_data.WearableShirt.WearableName,m_data.WearableShirt.WearablePrice,m_data.WearableShirt.ItemType);

            //-- Pants
            UINpcPrintSetItem m_toPrintPants = Instantiate(PrefabPrintItem, ItemHolder);
            m_toPrintPants.Init(m_data.WearablePants.WerableSmallImage, m_data.WearablePants.WearableName, m_data.WearablePants.WearablePrice, m_data.WearablePants.ItemType);
        }
    }

    private void OnEnable()
    {
        EventsHolder.ON_BUY += UpdateUserMoneyVisual;
    }

    private void OnDisable()
    {
        EventsHolder.ON_BUY -= UpdateUserMoneyVisual;
    }

    void UpdateUserMoneyVisual(float value)
    {
        PrintMoneyAmount.text = value.ToString();
    }
}
