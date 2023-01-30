using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField] private List<InventoryItemData> input = new List<InventoryItemData>();
    [SerializeField] private List<Recipe> recipeBook;

    // Start is called before the first frame update
    void Start()
    {
        CheckRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckRecipe() // do this on button press
    {
        foreach(var recipe in recipeBook)
        {
            if(recipe.CheckRecipe(input, out float successrate))
            {
                if(Random.Range(1,101) <= successrate)
                {
                    //give x amount of item to player and remove items from cauldron inventory
                    Debug.Log($"Crafted {recipe.amount} of {recipe.output.ToString()} with a {successrate}% chance of succeeding");
                }
                else
                {
                    //fail craft
                }
            }
            else
            {
                //fail craft
            }
        }
    }
}
