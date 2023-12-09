using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private IEnumerator coroutine; //refrence to our coroutine
    float seconds = 2f;
    public PlayerController playerController;
    public HitPlayer EnemyAttacksPlayer;
    public EnemyAI EnemyScript;
    public AudioSource GoblinDeath;
    public float Speed;
    public Transform target;
    public float minimumDistance;
    public float timeBetweenAttacks;
    private float nextAttackTime;
    public Animator enemyAnim;
    Vector3 Enemy;
    Vector3 AttackTarget;
    public LayerMask playerLayer;
    public int offset = 3;
    public float EnemyHealth = 100;
    public float Losehealth = 100;
    public bool isAttackingPlayer;
    private void Start()
    {
        transform.LookAt(target); // enemyPrefab look at player
        AttackTarget = FindObjectOfType<PlayerController>().transform.position; // we find the knightmovement position
    }
    void Update()
    {
       
        if (Vector3.Distance(transform.position, target.position) >= minimumDistance)//if the distance is >= the minimum distance
        {
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);//we transform the position of enemyPrefab towars our player position
            enemyAnim.SetBool("IsAttacking", false);//we set the enemyPrefab bool isattacking to false distance is >= the minimumDistance
         if (Vector3.Distance(transform.position, target.position) <= minimumDistance ) // if it is <= the minimum distance
        {
                transform.LookAt(target);
                enemyAnim.SetBool("IsAttacking", true);// we set our bool isattacking to true
                AttackOurPlayer();
              
            }
           
        }

        }
    
     public void LoseHealth(int damage)//enemyPrefab loses health
    {
        EnemyHealth -=damage;// our enemyPrefab health -= the damage
        if (EnemyHealth <= 0)//if enemyPrefab health is below zero or equal
        {
            enemyAnim.SetBool("IsDead", true);//we set the bool to dead is true
            GoblinDeath.Play();
            EnemyScript.enabled = false;//we disable the enemyPrefab script
            Destroy(this.gameObject,2f);//we destroy the enemyPrefab
        }
    }

    void AttackOurPlayer()
    {

        {
            isAttackingPlayer = true;
            EnemyAttacksPlayer.AttackOurPlayer();//we attack our player
         //   playerController.TakeDamage();
            Debug.Log("Enemy attacked Player");
        }
    }
       
    }


