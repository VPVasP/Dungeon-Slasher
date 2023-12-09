using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager instance;//our manager and it is static
    public TextMeshProUGUI coinstext; //our coinsPrefab text
    [SerializeField] int coin;//our default coin value =0
    [SerializeField] int coinValue=1;//the coin value 

    private void Awake()
    {
        instance = this;
    }

    public void ChangeCoins()
    {
        coin += coinValue; //coinsPrefab + our coinsPrefab value 
        coinstext.text = " " + coin.ToString(); //we take the int value and we make it a string so it shows in our game 

    }
}