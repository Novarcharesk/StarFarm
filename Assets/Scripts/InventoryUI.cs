using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<GameObject> inventorySlots; // List of inventory slot game objects
    private List<Text> starCountTexts; // List of star count Text components

    public enum StarColor
    {
        Red,
        Green,
        Blue,
        Yellow
    }

    private void Start()
    {
        // Initialize the starCountTexts list
        starCountTexts = new List<Text>();

        // Iterate over the inventory slots and retrieve the Text component from the child object
        foreach (GameObject slot in inventorySlots)
        {
            Text starCountText = slot.transform.GetChild(0).GetComponent<Text>();
            starCountTexts.Add(starCountText);
        }
    }

    public void UpdateStarCountTexts(int[] starCounts)
    {
        // Update the text values based on the starCounts array
        for (int i = 0; i < starCounts.Length; i++)
        {
            starCountTexts[i].text = "=" + starCounts[i].ToString();
        }
    }
}