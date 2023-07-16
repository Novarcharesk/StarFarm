using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellValue : MonoBehaviour
{

    public PlayerController playerController;

    private int current;

    public void SellRedGrape()
    {
        int current = playerController.grapeCount[0];
        playerController.CollectsolRuble(7 * current);
        playerController.ResetStarCount(StarColor.Red);
    }
    public void SellBlueGrape()
    {
        int current = playerController.grapeCount[2];
        playerController.CollectsolRuble(5 * current);
        playerController.ResetStarCount(StarColor.Blue);
    }

    public void SellGreenGrape()
    {
        int current = playerController.grapeCount[1];
        playerController.CollectsolRuble(3 * current);
        playerController.ResetStarCount(StarColor.Green);
    }

    public void SellYellowGrape()
    {
        int current = playerController.grapeCount[3];
        playerController.CollectsolRuble(10 * current);
        playerController.ResetStarCount(StarColor.Yellow);
    }

    public void BuyTomato()
    {
        playerController.SpendsolRuble(15);
    }
    public void BuyCarrot()
    {
        playerController.SpendsolRuble(30);
    }

    public void BuyCorn()
    {
        playerController.SpendsolRuble(50);
    }

}