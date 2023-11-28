using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager coinsManager; //our manager and it is static
    public TextMeshProUGUI coinstext; //our coins text
    [SerializeField] int coin;//our default coin value =0
    [SerializeField] int coinValue=1;//the coin value 

    private void Start()
    {
        if (coinsManager == null)//if it exists 
        {
           coinsManager = this; //this is our coins manager

        }
       
    }

    public void ChangeCoins()
    {
        coin += coinValue; //coins + our coins value 
        coinstext.text = " " + coin.ToString(); //we take the int value and we make it a string so it shows in our game 

    }
}