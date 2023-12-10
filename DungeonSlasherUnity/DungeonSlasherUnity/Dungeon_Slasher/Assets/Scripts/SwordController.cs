using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public Animator anim;


    private void OnCollisionEnter(Collision collision)
    {
        float randomAttackValue = Random.Range(15,30);
        if (collision.collider.CompareTag("Enemy"))
        {
            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
            {

                if (collision.collider.GetComponent<EnemyAI>().EnemyHealth > 0)
                {
                    collision.collider.GetComponent<EnemyAI>().LoseHealth(randomAttackValue);
                    Debug.Log(collision.collider.GetComponent<EnemyAI>().EnemyHealth);
                }
            }
        }



    }

    }

 
        
       
       
       


