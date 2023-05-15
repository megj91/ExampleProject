using UnityEngine;
using TMPro;
public class UINpcPrintSetItem : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image PrintSetImage;
    [SerializeField] private TextMeshProUGUI PrintSetName;
    [SerializeField] private TextMeshProUGUI PrintSetCost;

    private float ItemValue = 0;
    private string DataIndexName;
    private ItemType IsTorso;
    private UnityEngine.UI.Button LocalButton;
    private void Start()
    {
        LocalButton = GetComponent<UnityEngine.UI.Button>();
        LocalButton.onClick.AddListener(OnButtonPressed);
    }
    private void OnEnable()
    {
        EventsHolder.ON_DELETE_UI_ITEMS += OnDeleteItem;
    }
    private void OnDisable()
    {
        EventsHolder.ON_DELETE_UI_ITEMS -= OnDeleteItem;
    }
    public void Init(Sprite _imageSprite, string _setName, float _setCost, ItemType _type)
    {
        PrintSetImage.sprite    = _imageSprite;
        PrintSetName.text       = _setName;
        PrintSetCost.text       = _setCost.ToString();
        DataIndexName           = _setName;
        IsTorso                 = _type;
        ItemValue               = _setCost;
    }

    private void OnDeleteItem()
    {
        Destroy(gameObject);
    }

    private void OnButtonPressed()
    {
        ShopTransactionManager.SetTransactionValues(DataIndexName, ItemValue,IsTorso);
    }
}
