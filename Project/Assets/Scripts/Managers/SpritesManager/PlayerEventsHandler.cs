using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventsHandler : MonoBehaviour
{
    public delegate void WearableDataHandler(WearableData wearableData);

    public static event WearableDataHandler OnBuyPants;
    public static event WearableDataHandler OnBuyShirts;
    public static event WearableDataHandler OnWearPants;
    public static event WearableDataHandler OnWearShirts;

    private void OnEnable()
    {
        OnBuyPants += PopulatePantsSprites;
        OnBuyShirts += PopulateTorsoSprites;
        OnWearPants += PopulatePantsSprites;
        OnWearShirts += PopulateTorsoSprites;
    }

    private void OnDisable()
    {
        OnBuyPants -= PopulatePantsSprites;
        OnBuyShirts -= PopulateTorsoSprites;
        OnWearPants -= PopulatePantsSprites;
        OnWearShirts -= PopulateTorsoSprites;
    }

    private void PopulateTorsoSprites(WearableData wearableData)
    {
        FindObjectOfType<PlayerAnimationsHandler>().PopulateTorsoSprites(wearableData);
    }

    private void PopulatePantsSprites(WearableData wearableData)
    {
        FindObjectOfType<PlayerAnimationsHandler>().PopulatePantsSprites(wearableData);
    }
}
