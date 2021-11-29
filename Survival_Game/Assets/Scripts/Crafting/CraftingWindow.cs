using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingWindow : MonoBehaviour
{
    public CraftingRecipeUI[] recipeUIs;

    public static CraftingWindow instance;

    private void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        Inventory.instance.onOpenInventory.AddListener(OnOpenInventory);
    }

    void OnDisable()
    {
        Inventory.instance.onOpenInventory.RemoveListener(OnOpenInventory);
    }

    void OnOpenInventory()
    {
        gameObject.SetActive(false);
    }

    public void Craft(CraftingRecipe recipe)
    {

    }
}
