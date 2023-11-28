using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public GameObject doors;
    public GameObject realDoor;
    public Animator KnightAnim;
    public GameObject DoorText;
    public GameObject NewRoom;
    public bool canPressP;
    // Start is called before the first frame update
  
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We are inside");
        if (other.gameObject.CompareTag("Player")) // if tag is player
        {
            DoorText.SetActive(true);//we set our tag to true
            
            
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            canPressP = false;
            KnightAnim.Play("hit2");
            doors.SetActive(false);
            realDoor.SetActive(false);
            DoorText.SetActive(false);
            NewRoom.SetActive(true); //we set our variables false and true
        }
    }
    private void OnTriggerExit(Collider other)
        {
            Debug.Log("We are Outside");
            
                DoorText.SetActive(false);//we set our gameobject to false
            


        }
}
    
       


