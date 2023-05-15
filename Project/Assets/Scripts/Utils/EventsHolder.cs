using System.Collections.Generic;
public static class EventsHolder 
{
    public delegate void  DELEGATE_ON_NPC_STORE_INTERACTION<T>(T _args);
    public delegate void DELEGATE_DELETE_UI_ITEMS();

    public static DELEGATE_ON_NPC_STORE_INTERACTION<List<WearableSetScriptable>> ON_NPC_STORE_INTERACTION;
    public static DELEGATE_ON_NPC_STORE_INTERACTION<WearableData> ON_BUY_SHIRTS;
    public static DELEGATE_ON_NPC_STORE_INTERACTION<WearableData> ON_BUY_PANTS;
    public static DELEGATE_ON_NPC_STORE_INTERACTION<float> ON_BUY;



    public static DELEGATE_ON_NPC_STORE_INTERACTION<WearableData> ON_WEAR_SHIRTS;
    public static DELEGATE_ON_NPC_STORE_INTERACTION<WearableData> ON_WEAR_PANTS;



    public static DELEGATE_DELETE_UI_ITEMS ON_DELETE_UI_ITEMS;

}
