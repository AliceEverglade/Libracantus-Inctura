using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="inventory/recipe")]
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
        successChance = baseSuccessChance - (10 * (input.Count - ingredientCount));
        
        foreach (var ingredient in ingredients)
        {
            if (input.Contains(ingredient)) 
            { 
                ingredientsCheck++; 
            }
        }
        bool success = ingredientsCheck == ingredientCount;
        return success;
    }
}
