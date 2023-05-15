using UnityEngine;

public abstract class UIView : ScriptableObject, IUIView
{
    [SerializeField] GameObject viewPrefab;

    protected GameObject viewInstance;

    public virtual void Show(Transform parent)
    {
        if (viewInstance == null)
        {
            viewInstance = GameObject.Instantiate(viewPrefab, parent);
        }
        viewInstance.SetActive(true);
    }

    public virtual void Hide()
    {
        if (viewInstance != null)
        {
            viewInstance.SetActive(false);
        }
    }
}