using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public List<Recipe> recipeBook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckRecipe(List<InventoryItemData> input) // do this on button press
    {
        foreach(var recipe in recipeBook)
        {
            if(recipe.CheckRecipe(input, out float successrate))
            {
                if(Random.Range(1,101) <= successrate)
                {
                    //give x amount of item to player and remove items from cauldron inventory
                }
            }
        }
    }
}
