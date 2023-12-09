using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public Animator playerAnim;//reference to our player animator 
    public LayerMask EnemyLayers;//enemyPrefab layers
    Animator SwordAttack1;//refrence to our animator
    public int AttackDamage = 20;
    public int AttackDamage2 = 50;
    public GameObject Sword;//our sword game object
    public float AttackRate = 2f;
    public float nextAttackTime = 0f;
    public Transform attackPoint;
    public float attackRange;
    public EnemyAI enemyscript;//refrence to our script
    public Collider[] destroyenemies;//our collider enemies
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        HitEnemies();
    }

    void HitEnemies()
    {
        if (this.playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))//if we play a certain animation
        {
            destroyenemies = Physics.OverlapSphere(attackPoint.position, attackRange, EnemyLayers);
            foreach (Collider enemies in destroyenemies)//we create a foreach
            {

                enemies.GetComponent<EnemyAI>().LoseHealth(AttackDamage2);//we call the object we hit script to lose health
                Debug.Log("We hit" + enemies.name);
            }
        }
    }
    
      
            
    }

 
        
       
       
       


