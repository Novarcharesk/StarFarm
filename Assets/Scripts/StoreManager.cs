using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StoreItem
{
    public string itemName;
    public Sprite itemImage;
    public int itemPrice;
    public GameObject itemPrefab;
}

public class StoreManager : MonoBehaviour
{
    public GameObject storePanel;
    public GameObject itemButtonPrefab;
    public Transform buttonContainer;
    public List<StoreItem> storeItems;
    private int playerCurrency = 100; // Example: Player's currency amount

    private void Start()
    {
        // Populate the store UI with buttons for each store item
        PopulateStoreUI();
    }

    private void PopulateStoreUI()
    {
        foreach (StoreItem item in storeItems)
        {
            // Create a button for each store item
            GameObject buttonObj = Instantiate(itemButtonPrefab, buttonContainer);
            Button itemButton = buttonObj.GetComponent<Button>();

            // Set the button's label and image based on the store item
            Text buttonText = buttonObj.GetComponentInChildren<Text>();
            Image buttonImage = buttonObj.GetComponent<Image>();

            buttonText.text = item.itemName;
            buttonImage.sprite = item.itemImage;

            // Add an onclick listener to the button to handle the purchase
            itemButton.onClick.AddListener(() => PurchaseItem(item));
        }
    }

    private void PurchaseItem(StoreItem item)
    {
        // Check if the player has enough currency to make the purchase
        // If so, deduct the item price from the player's currency
        // and instantiate the item's prefab in the game world

        bool canAfford = CheckPlayerCurrency(item.itemPrice);

        if (canAfford)
        {
            DeductCurrency(item.itemPrice);
            Instantiate(item.itemPrefab);
        }
        else
        {
            Debug.Log("Insufficient funds to purchase " + item.itemName);
        }
    }

    private bool CheckPlayerCurrency(int price)
    {
        return playerCurrency >= price;
    }

    private void DeductCurrency(int amount)
    {
        playerCurrency -= amount;
        Debug.Log("Deducted " + amount + " currency. Remaining balance: " + playerCurrency);
    }

    public void OpenStorePanel()
    {
        storePanel.SetActive(true);
    }

    public void CloseStorePanel()
    {
        storePanel.SetActive(false);
    }
}