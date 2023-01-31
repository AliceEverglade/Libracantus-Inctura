using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField] private InventoryHolder cauldronInventory;
    [SerializeField] private InventoryDisplay display;
    [SerializeField] private List<InventoryItemData> input = new List<InventoryItemData>();
    [SerializeField] private List<Recipe> recipeBook;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckRecipe() // do this on button press
    {
        Debug.Log("Recipe Started");
        GetInventory();
        foreach(var recipe in recipeBook)
        {
            if(recipe.CheckRecipe(input, out float successrate))
            {
                Debug.Log("Recipe Found");
                if (Random.Range(1,101) <= successrate)
                {
                    Debug.Log("Item Created");
                    //give x amount of item to player and remove items from cauldron inventory
                    ClearInventory();
                    cauldronInventory.PrimaryInventorySystem.AddToInventory(recipe.output, recipe.amount);
                }
                else
                {
                    ClearInventory();
                }
            }
            else
            {
                ClearInventory();
            }
        }
    }

    private void GetInventory()
    {
        input = new List<InventoryItemData>();
        foreach(var slot in cauldronInventory.PrimaryInventorySystem.InventorySlots)
        {
            var item = slot.ItemData;
            input.Add(item);
        }
    }
    private void ClearInventory()
    {
        foreach (var slot in cauldronInventory.PrimaryInventorySystem.InventorySlots)
        {
            slot.ClearSlot();
        }
        foreach(var UISlot in display.SlotDictionary)
        {
            UISlot.Key.UpdateUISlot();
        }
    }
}
