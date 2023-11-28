using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public Animator EnemyAnim;
    public Transform target;
    public LayerMask playerLayer;
    public float nextAttackTime;
    public float attackTime;
    public KnightMovement ourMove;
   public Collider[] AttackThisPlayer;
    public void AttackOurPlayer()
    {
        if (this.EnemyAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
        {
          AttackThisPlayer = Physics.OverlapSphere(target.position, nextAttackTime, playerLayer);
            foreach (Collider player in AttackThisPlayer)//we make a foreach so we can attack
            {
                  ourMove.TakeDamage(); // we call our move script fuction
                Debug.Log("Enemy attacked Player");
            }
        }
    }
        
    }

