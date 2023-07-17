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
        playerController.ResetGrapeCount(StarColor.Red);
        playerController.UpdateGrapeCountUI();
    }
    public void SellBlueGrape()
    {
        int current = playerController.grapeCount[2];
        playerController.CollectsolRuble(5 * current);
        playerController.ResetGrapeCount(StarColor.Blue);
        playerController.UpdateGrapeCountUI();
    }

    public void SellGreenGrape()
    {
        int current = playerController.grapeCount[1];
        playerController.CollectsolRuble(3 * current);
        playerController.ResetGrapeCount(StarColor.Green);
        playerController.UpdateGrapeCountUI();
    }

    public void SellYellowGrape()
    {
        int current = playerController.grapeCount[3];
        playerController.CollectsolRuble(10 * current);
        playerController.ResetGrapeCount(StarColor.Yellow);
        playerController.UpdateGrapeCountUI();
    }

    public void BuyTomato()
    {
        playerController.SpendsolRuble(15, 0);
    }
    public void BuyCarrot()
    {
        playerController.SpendsolRuble(30, 1);
    }

    public void BuyCorn()
    {
        playerController.SpendsolRuble(50, 2);
    }

}