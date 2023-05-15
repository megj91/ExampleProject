using UnityEngine;

public interface IUIView
{
    void Show(Transform parent);
    void Hide();
}

public interface IExecuteActionOnTrigger
{
    void OnTriggerExecution();
}
