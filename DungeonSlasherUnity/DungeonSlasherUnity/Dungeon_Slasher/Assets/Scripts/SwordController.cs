using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public Animator anim;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
            {

                if (collision.collider.GetComponent<EnemyAI>().EnemyHealth > 0)
                {
                    collision.collider.GetComponent<EnemyAI>().LoseHealth(5);
                    Debug.Log(collision.collider.GetComponent<EnemyAI>().EnemyHealth);
                }
            }
        }



    }
    }

 
        
       
       
       


