using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public AudioSource collectCoinSound;//Our Coin Sound
    public GameObject PickupEffect;//our pickup effect
    private void Start()
    {
        collectCoinSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))//if he enters with tag
        {
            CoinsManager.instance.ChangeCoins();
            collectCoinSound.Play(); //play the coinsPrefab audio
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
        GameObject pickupEffectClone=    Instantiate(PickupEffect, transform.position, transform.rotation);//we instantiate the effect
            Destroy(pickupEffectClone);
            Destroy(this.gameObject,1f);//we destroy the coin after all the above are completed
           

        }
    }
}

