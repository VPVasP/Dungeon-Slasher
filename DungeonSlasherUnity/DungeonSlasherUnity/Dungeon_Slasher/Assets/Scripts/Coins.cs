using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public AudioSource collectCoinSound;//Our Coin Sound
    public CoinsManager coinsManager;//Our refrence to the coinsManager
    public GameObject PickupEffect;//our pickup effect
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))//if he enters with tag
        {
            coinsManager.ChangeCoins();//change our coins through our manager
            collectCoinSound.Play(); //play the coins audio
               Destroy(this.gameObject);//we destroy the coin after all the above are completed
            Instantiate(PickupEffect, transform.position, transform.rotation);//we instantiate the effect
            Destroy(PickupEffect, 1f);//we destroy it after 1 sec

        }
    }
}

