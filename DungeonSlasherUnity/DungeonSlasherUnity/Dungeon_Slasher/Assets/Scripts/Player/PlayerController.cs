using UnityEngine;

public class PlayerController : Player
{
    public static PlayerController instance;
    [SerializeField] private float maximumSpeed;//our max speed
    [SerializeField] private float rotationSpeed; //our rotation speed
    private Animator animator; //refrence to our animator 
    private CharacterController characterController; //refrence to our controller
    private float originalStepOffset; //our original offset 
    public bool grounded;
    public bool isAttacking = false;
    public LayerMask layer;
    public LayerMask groundMask;
    public float playerHealth = 100;
    private PlayerStats playerStats;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Cursor.visible = false; // hide cursor
        animator = GetComponent<Animator>(); // reference to animator
        characterController = GetComponent<CharacterController>(); // reference to character controller
        originalStepOffset = characterController.stepOffset; // store original offset
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        Move(); //call Move method
        Attack(); //call Attack method 
    }

    //implementing the abstract Move method from the Player class
    public override void Move()
    {
        //take inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput); // movement direction
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude); // clamp magnitude between 0 and 1
        float speed = inputMagnitude * maximumSpeed; // calculate speed
        movementDirection.Normalize(); // normalize direction
        Vector3 velocity = movementDirection * speed; // calculate velocity
        characterController.Move(velocity * Time.deltaTime); // move the character controller

        //rotation and animation logic
        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsRunning", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    //implementing the abstract Attack method from the Player class
    public override void Attack()
    {
        if (Input.GetMouseButtonDown(0)) //left click for attack
        {
            animator.Play("Attack01");
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    //implementing the abstract LoseHealth method from the Player class
    public override void LoseHealth(float damage)
    {
      playerStats.LoseHealth(damage);
    }

    public override void Die()
    {
        playerStats.Die();
    }
}








