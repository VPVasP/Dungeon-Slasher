using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHealth : MonoBehaviour
{
    public KnightMovement playerMove;
    public GameObject PickupEffect;//our pickup effect
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))//if he enters with tag
        {


            Destroy(this.gameObject);//we destroy the heart 
            playerMove.MoreHealth();//we give player more health from health script
            Instantiate(PickupEffect, transform.position, transform.rotation);//we instantiate the effect
            Destroy(PickupEffect, 1f);//we destroy it after 1 sec

        }
    }
}
