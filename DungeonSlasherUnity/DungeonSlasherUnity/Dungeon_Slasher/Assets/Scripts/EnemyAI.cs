using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float Speed;
    public Transform target;
    public float minimumDistance;
    public float timeBetweenAttacks;
    private float nextAttackTime;
    public Animator enemyAnim;
    public float EnemyHealth = 100;
    public bool isAttackingPlayer;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        transform.LookAt(target);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) >= minimumDistance)
        {
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
            enemyAnim.SetBool("isAttacking", false);
            if (Vector3.Distance(transform.position, target.position) <= minimumDistance)
            {
                transform.LookAt(target);
                if (Time.time >= nextAttackTime)
                {
                    isAttackingPlayer = true;
                    enemyAnim.SetBool("isAttacking", true);
                    Debug.Log("AttackingPlayer");
                    nextAttackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
      
    }

    public void LoseHealth(int damage)
    {
        EnemyHealth -= damage;
        if (EnemyHealth <= 0)
        {
            enemyAnim.SetTrigger("Dead");
            Destroy(this.gameObject, 2f);
            Debug.Log("EnemyDied" + this.gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, minimumDistance);
    }
}