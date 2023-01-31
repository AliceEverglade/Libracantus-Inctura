using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Inventory/Recipe")]
public class Recipe : ScriptableObject
{
    public new string name;
    [Header("Ingredients")]
    public List<InventoryItemData> ingredients;
    public int ingredientCount;
    [Header("Output")]
    public InventoryItemData output;
    public float baseSuccessChance;
    public int amount;

    public bool CheckRecipe(List<InventoryItemData> input, out float successChance)
    {
        ingredientCount = ingredients.Count;
        int ingredientsCheck = 0;
        successChance = baseSuccessChance;
        
        foreach (var ingredient in ingredients)
        {
            if (input.Contains(ingredient)) 
            { 
                ingredientsCheck++; 
            }
            else if(ingredient != null)
            {
                successChance -= 10f;
            }
        }
        bool success = ingredientsCheck == ingredientCount;
        return success;
    }
}
