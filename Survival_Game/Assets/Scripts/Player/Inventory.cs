using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlots;
    public ItemSlot[] slots;

    public GameObject inventoryWindow;
    public Transform dropPosition;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;

    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatNames;
    public TextMeshProUGUI selectedItemStatValues;
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unequipButton;
    public GameObject dropButton;

    private int curEquipIndex;

    //components
    private PlayerController controller;

    [Header("Events")]
    public UnityEvent onOpenInventory;
    public UnityEvent onCloseInventory;

    //singleton
    public static Inventory instance;

    private void Awake()
    {
        instance = this;
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        inventoryWindow.SetActive(false);
        slots = new ItemSlot[uiSlots.Length];

        //initialize the slots
        for(int x = 0; x < slots.Length; x++)
        {
            slots[x] = new ItemSlot();
            uiSlots[x].index = x;
            uiSlots[x].Clear();
        }
    }

    // opens or closes the inventory
    public void Toggle()
    {

    }

    // is the inventory currently open?
    public bool Isopen()
    {
        return inventoryWindow.activeInHierarchy;
    }

    // adds the requested item to the player's inventory
    public void AddItem(ItemData item)
    {
        if(item.canStack)
        {
            ItemSlot slotToStackTo = GetItemStack(item);

            if(slotToStackTo != null)
            {
                slotToStackTo.quantity++;
                UpdateUI();
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();

        if(emptySlot != null)
        {
            emptySlot.item = item;
            emptySlot.quantity = 1;
            UpdateUI();
            return;
        }

        ThrowItem(item);
    }

    // spawns the item infront of the player
    void ThrowItem(ItemData item)
    {

    }

    // updates the UI slots
    void UpdateUI()
    {

    }

    // returns the item slot that the requested item can be stacked on
    // returns null if there is no stack available
    ItemSlot GetItemStack(ItemData item)
    {
        return null;
    }

    // returns an empty slot in the inventory
    // if there are no empty slots - return null
    ItemSlot GetEmptySlot()
    {
        return null;
    }

    // called when we click on an item slot
    public void SelectItem(int index)
    {

    }

    // called when the inventory opens or the currently selected item has depleted
    void ClearSelectedItemWindow()
    {

    }

    // called when the "Use" button is pressed
    public void OnUseButton()
    {

    }

    // called when the "Equip" button is pressed
    public void OnEquipButton()
    {

    }

    // unequips the requested item
    void UnEquip(int inedex)
    {

    }

    // called when the "UnEquip" button is pressed
    public void OnUnEquipButton()
    {

    }

    // called when the "Drop" button is pressed
    public void OnDropButton()
    {

    }

    // removes the currently selected item
    void RemoveSelectedItem()
    {

    }

    public void RemoveItem(ItemData item)
    {

    }

    // does the player have "quantity" amount of "item"s? later for crafting
    public bool HasItems(ItemData item, int quantity)
    {
        return false;
    }
}

public class ItemSlot
{
    public ItemData item;
    public int quantity;
}