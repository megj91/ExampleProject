using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[RequireComponent (typeof(PlayerMovement))]
public class PlayerAnimationsHandler : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer TorsoRenderer;
    [SerializeField] private SpriteRenderer PantsRenderer;


    private ISpriteManager TorsoSpriteManager;
    private ISpriteManager TantsSpriteManager;


    private Dictionary<PlayerOrientation, int> SpriteCounters;

    PlayerOrientation NewOrientation;
    PlayerOrientation CurrentOrientation;

    private void Awake()
    {
        TorsoSpriteManager = new TorsoSpriteManager();
        TantsSpriteManager = new PantsSpriteManager();

        SpriteCounters = new Dictionary<PlayerOrientation, int>
        {
            { PlayerOrientation.Up, 0 },
            { PlayerOrientation.Down, 0 },
            { PlayerOrientation.Left, 0 },
            { PlayerOrientation.Idle, 0 },
            { PlayerOrientation.Right, 0 }
        };

    }


   
    private void OnEnable()
    {
        EventsHolder.ON_BUY_PANTS   += PopulatePantsSprites;
        EventsHolder.ON_BUY_SHIRTS  += PopulateTorsoSprites;
        EventsHolder.ON_WEAR_PANTS  += PopulatePantsSprites;
        EventsHolder.ON_WEAR_SHIRTS += PopulateTorsoSprites;
    }
    private void OnDisable()
    {
        EventsHolder.ON_BUY_PANTS   -= PopulatePantsSprites;
        EventsHolder.ON_BUY_SHIRTS  -= PopulateTorsoSprites;
        EventsHolder.ON_WEAR_PANTS  -= PopulatePantsSprites;
        EventsHolder.ON_WEAR_SHIRTS -= PopulateTorsoSprites;
    }

    public void ChangeAnimationStatus(PlayerOrientation playerOrientation)
    {
        _animator.Play(playerOrientation.ToString());

        CurrentOrientation = playerOrientation;
    }

    public void PopulateTorsoSprites(WearableData newTorsoSprites)
    {
        TorsoSpriteManager.PopulateSprites(newTorsoSprites);
        TorsoRenderer.sprite = TorsoSpriteManager.GetSprite(PlayerOrientation.Down, 0);
    }

    public void PopulatePantsSprites(WearableData newPantsSprites)
    {
        TantsSpriteManager.PopulateSprites(newPantsSprites);
        PantsRenderer.sprite = TantsSpriteManager.GetSprite(PlayerOrientation.Down, 0);
    }


   public void TriggerAnimation()
    {
        if (CurrentOrientation == PlayerOrientation.None)
            return;

        if(TorsoSpriteManager.GetSpriteCount(CurrentOrientation) >0)
            TorsoRenderer.sprite = TorsoSpriteManager.GetSprite(CurrentOrientation, SpriteCounters[CurrentOrientation]);

        if (TantsSpriteManager.GetSpriteCount(CurrentOrientation) > 0)
            PantsRenderer.sprite = TantsSpriteManager.GetSprite(CurrentOrientation, SpriteCounters[CurrentOrientation]);

        SpriteCounters[CurrentOrientation]++;
        int spriteCount = TorsoSpriteManager.GetSpriteCount(CurrentOrientation);
        if (SpriteCounters[CurrentOrientation] >= spriteCount)
            SpriteCounters[CurrentOrientation] = 0;

        if(CurrentOrientation == PlayerOrientation.Idle)
        {
            for (int i = 0; i < SpriteCounters.Count; i++)
            {
                PlayerOrientation key = SpriteCounters.Keys.ElementAt(i);
                SpriteCounters[key] = 0;
            }
        }

    }




 

}
