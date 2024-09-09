using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager instance;//our manager and it is static
    public TextMeshProUGUI coinstext; //our coinsPrefab text
    public int coin;//our default coin value =0

    private void Awake()
    {
        instance = this;
    }

    public void ChangeCoins(int coinValue)
    {
        coin += coinValue; //coinsPrefab + our coinsPrefab value 
        coinstext.text = "Coins " + coin.ToString(); //we take the int value and we make it a string so it shows in our game 
    }
}