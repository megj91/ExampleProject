using UnityEngine;

public class UIPlayerIntventoryView : MonoBehaviour
{
    [SerializeField] private UIPrintPlayerSetItem PrefabPrintItem;
    [SerializeField] private RectTransform TransformHolder;
    public void OnEnable()
    {
        for (int i = 0; i < TransformHolder.childCount; i++)
        {
            TransformHolder.GetChild(i).gameObject.GetComponent<UIPrintPlayerSetItem>().OnDeleteItem();
        }
        for (int i = 0; i < PlayerSessionData.OwnedClothes.Count; i++)
        {
            WearableData m_data = ShopTransactionManager.GetWaearableData(PlayerSessionData.OwnedClothes[i]);
            UIPrintPlayerSetItem m_PrintItem = Instantiate(PrefabPrintItem, TransformHolder);
            m_PrintItem.Init(m_data.WerableSmallImage, m_data.WearableName, 0f, m_data.ItemType);
        }
    }
}
