using UnityEngine;

public class EnemyAI : Enemy
{
    public float Speed;
    public Transform target;
    public float minimumDistance;
    public float timeBetweenAttacks;
    private float nextAttackTime;
    [SerializeField] private Animator enemyAnim;
    public float EnemyHealth = 100;
    public bool isAttackingPlayer = false;
    public bool isMoving = false;
    private AudioSource aud;
    [SerializeField] private AudioClip[] enemyAudios;
    private bool isHurt = false;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        transform.LookAt(target);
        aud = GetComponent<AudioSource>();
        enemyAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        Chase();  
    }
    public override void Chase()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer > minimumDistance)
        {
            isMoving = true;
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
            enemyAnim.SetBool("isAttacking", false);
        }
        else if (distanceToPlayer <= minimumDistance)
        {
            isMoving = false;
            Attack();  //call Attack method overridden from the abstract Enemy class
        }
    }

    //implementing the abstract method Attack from the Enemy class
    public override void Attack()
    {
        float randomAttackValue = Random.Range(5, 10);
        if (Time.time >= nextAttackTime && !isHurt && target.GetComponent<PlayerStats>().isDead == false)
        {
            aud.clip = enemyAudios[0];
            aud.Play();
            isAttackingPlayer = true;
            enemyAnim.SetBool("isAttacking", true);
            target.GetComponent<PlayerStats>().LoseHealth(randomAttackValue);
            target.GetComponent<Animator>().SetTrigger("Hurt");
            Debug.Log("AttackingPlayer");
            nextAttackTime = Time.time + timeBetweenAttacks;
        }
        else if (target.GetComponent<PlayerStats>().health <= 0)
        {
            target.GetComponent<PlayerStats>().isDead = true;
            Debug.Log("DIED");
        }
    }

    public override void LoseHealth(float damage)
    { 
        EnemyHealth -= damage;
        enemyAnim.SetTrigger("Hurt");
        Debug.Log("Enemy Attacked");
        isAttackingPlayer = false;
        isHurt = true;

        if (EnemyHealth <= 0)
        {
            aud.clip = enemyAudios[1];
            aud.Play();
            enemyAnim.SetTrigger("Dead");
            Speed = 0;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Destroy(gameObject, 2f);
            Debug.Log("EnemyDied: " + gameObject.name);
            isMoving = false;
            isAttackingPlayer = false;
            enabled = false;
            GameManager.instance.UpdateEnemies();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, minimumDistance);
    }
}