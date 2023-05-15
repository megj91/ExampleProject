using UnityEngine;

[CreateAssetMenu(fileName = "Wearable", menuName = "Scriptables/Create Wearable", order = 1)]
public class WearableSetScriptable : ScriptableObject
{
    public string WearableSetName;
    public WearableData WearableShirt;
    public WearableData WearablePants;

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(WearableShirt.WearableID))
        {
            WearableShirt.WearableID = Uuid.UUID_Make();
        }
        if (string.IsNullOrEmpty(WearablePants.WearableID))
        {
            WearablePants.WearableID = Uuid.UUID_Make();
        }
    }
}
