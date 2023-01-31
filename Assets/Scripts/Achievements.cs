using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/WinLoseConditions")]
public class Achievements : ScriptableObject
{
    public List<InventoryItemData> dangerousItems;
    public List<InventoryItemData> winItems;

    public void CheckWin(InventoryItemData item)
    {
        if (winItems.Contains(item))
        {
            Debug.Log("you won!");
        }
    }

    public void CheckDanger(InventoryItemData item)
    {
        if (dangerousItems.Contains(item))
        {
            Debug.Log($"you died making {item}");
        }
    }
}
