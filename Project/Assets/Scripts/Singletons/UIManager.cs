using System.Collections.Generic;
using UnityEngine;

public enum ViewType
{
    InventoryMenu,
    StoreMenu,
}

public class UIManager : Singleton<UIManager>
{

    [SerializeField] Transform _canvasTransform;

    private Dictionary<ViewType, IUIView> _views = new Dictionary<ViewType, IUIView>();

    ViewType currentViewName;


    public void RegisterView(ViewType viewName, IUIView view)
    {
        if (!_views.ContainsKey(viewName))
        {
            _views.Add(viewName, view);
        }

    }

    public void UnregisterView(ViewType viewName)
    {
        if (_views.ContainsKey(viewName))
        {
            _views.Remove(viewName);
        }
    }

    public async void ChangeView(ViewType nextViewName)
    {
        IUIView currentView;
        IUIView nextView;

        _views.TryGetValue(currentViewName, out currentView);
        _views.TryGetValue(nextViewName, out nextView);

        if (currentView != null)
        {
            currentView.Hide();
            await System.Threading.Tasks.Task.Delay(0);
        }

        if (nextView != null)
        {
            nextView.Show(_canvasTransform);
        }
    }

}
