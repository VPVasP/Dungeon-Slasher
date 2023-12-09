using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] private float maximumSpeed;//our max speed
    [SerializeField] private float rotationSpeed; //our rotation speed
    private Animator animator; //refrence to our animator 
    private CharacterController characterController; //refrence to our controller
    private float originalStepOffset; //our original offset 
    public bool grounded;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        Cursor.visible = false; //we set the cursor to false
        animator = GetComponent<Animator>(); //refrence to our animator
        characterController = GetComponent<CharacterController>();//refrence for our character controller
        originalStepOffset = characterController.stepOffset; // we place values inside our original offset which is our character controller offset
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
        float speed = inputMagnitude * maximumSpeed; //our new float speed
        movementDirection.Normalize();//we normalize our direction
        Vector3 velocity = movementDirection * speed; //our vector3 velocity
        characterController.Move(velocity * Time.deltaTime); //we move our character controller
        if (movementDirection != Vector3.zero) // if movement direction isn't equal to zero 
        {
            animator.SetBool("IsRunning", true);//we set our bool to run
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);// we set our rotation as our move direction 

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);//we rotate towards 
        }
        else if (movementDirection == Vector3.zero)
        {
            animator.SetBool("IsRunning", false); //else we can't run
        }


    }
}


  


    




