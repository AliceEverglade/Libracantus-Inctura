using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionCheck : ScriptableObject
{
    public List<InventoryItemData> progressionItems;
    public List<InventoryItemData> leftProgressionItems;
    [SerializeField] private MusicHandler handler;

    public void ResetProgression()
    {
        leftProgressionItems = progressionItems;
        handler = FindObjectOfType<MusicHandler>();
    }

    public void CheckProgression(InventoryItemData item)
    {
        if (leftProgressionItems.Contains(item))
        {
            leftProgressionItems.Remove(item);
            handler.LayerUpdate(1);
        }
    }
}
