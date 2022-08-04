using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiItemHandler : MonoBehaviour
{
    [SerializeField]
    private Item item;
    [SerializeField]
    private TextMeshProUGUI textUI;
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
        UpdateUIQuantity();
    }

    public void ResetItem()
    {
        if (GameObject.Find("Store") != null && item.quantity != 0)
        {
            item.quantity = 0;
            UpdateUIQuantity();
        }
    }

    public void UpdateUIQuantity()
    {
        textUI.text = item.quantity.ToString();
    }
}