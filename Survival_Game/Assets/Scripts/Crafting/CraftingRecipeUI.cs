using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingRecipeUI : MonoBehaviour
{
    public CraftingRecipe recipe;
    public Image backgroundImage;
    public Image icon;
    public TextMeshProUGUI itemName;
    public Image[] resourceCosts;

    public Color canCraftColor;
    public Color cannotCraftColor;
    private bool canCraft;

    public void UpdateCanCraft()
    {
        canCraft = true;

        for(int i = 0; i < recipe.cost.Length; i++)
        {
            if(Inventory.instance.HasItems(recipe.cost[i].item, recipe.cost[i].quantity))
            {
                canCraft = false;
                break;
            }
        }

        backgroundImage.color = canCraft ? canCraftColor : cannotCraftColor;
    }
}
