using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class KnightMovement : MonoBehaviour
{
    private IEnumerator coroutine; //refrence to our coroutine
    public float seconds = 2f; //the delay of the scene
    public Pause PauseMenu; //refrence to our pause Menu
    public GameObject YouDiedText; //you died text when player dies
   [SerializeField] private float maximumSpeed;//our max speed
   [SerializeField] private float rotationSpeed; //our rotation speed
    public KnightMovement KnightMove; //refrence to our movement
    private Animator animator; //refrence to our animator 
    private CharacterController characterController; //refrence to our controller
   private float originalStepOffset; //our original offset 
    public float Health = 100f;//our health
    public float MaxHealth = 100;//our max health
    public TextMeshProUGUI HealthText;//our health text
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;//Our Health is equal to our max health
        Cursor.visible = false; //we set the cursor to false
        animator = GetComponent<Animator>(); //refrence to our animator
        characterController = GetComponent<CharacterController>();//refrence for our character controller
        originalStepOffset = characterController.stepOffset; // we place values inside our original offset which is our character controller offset
        HealthText.text ="Health: "+ Health.ToString();
    }
  

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // if left click we attack
        {
            animator.Play("Attack01");//this is for game desing purposes, if he runs he can attack, if i wanted it to not attack when he is running i would set up a bool for that
        }

       
        //we take our inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput); //our vector3 movement direction
      float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude); //it clamps between the value of never below zero 0 and never above 1
        float speed =inputMagnitude*  maximumSpeed; //our new float speed
        movementDirection.Normalize();//we normalize our direction
        Vector3 velocity = movementDirection * speed; //our vector3 velocity
        characterController.Move(velocity * Time.deltaTime); //we move our character controller
        if (movementDirection != Vector3.zero) // if movement direction isn't equal to zero 
        {
            animator.SetBool("IsRunning", true);//we set our bool to run
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);// we set our rotation as our move direction 

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);//we rotate towards 
        }
       else if(movementDirection==Vector3.zero)
        {
            animator.SetBool("IsRunning", false); //else we can't run
        }
        if (Health <= 0)
        {
            Die();
        }
      
        }
    
    public void TakeDamage()
    {
        Health -= 20;
        HealthText.text = "Health: " + Health.ToString();
    }
    public void MoreHealth()
    {
        if (Health >= 100)
        {
            Health += 0;
            HealthText.text = "Health: " + Health.ToString();
        }
        else
        {
            Health += 10;
            HealthText.text = "Health: " + Health.ToString();
        }
       
    }
    public void Die()
    {
        HealthText.enabled = false;
        KnightMove.enabled = false; //we disable our move
        animator.Play("Death"); //we play the death animation
        YouDiedText.SetActive(true); //we set active the death panel
        PauseMenu.enabled = false; // we disable the pause menu ability just in case
        coroutine = DelayScene(2f);//we say that the DelayScene is equal to coroutine and the time 2 seconds
        StartCoroutine(coroutine);//we call the coroutine
    }
    IEnumerator DelayScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);//we wait for specific time
        SceneManager.LoadScene("Game");
    }

}


  


    




