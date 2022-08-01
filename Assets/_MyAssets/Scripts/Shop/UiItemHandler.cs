using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiItemHandler : MonoBehaviour
{
    [SerializeField]
    private Item item;
    private ItemMenu itemMenu;
    private ItemManager itemManager;
    void Start()
    {
        GetReference();
    }

    private void GetReference()
    {
        itemManager = FindObjectOfType<ItemManager>();
        itemMenu = FindObjectOfType<ItemMenu>();
    }

    public void OnClick()
    {
        itemManager.Buy(item);
        itemMenu.StoreToggle();
    }
}
