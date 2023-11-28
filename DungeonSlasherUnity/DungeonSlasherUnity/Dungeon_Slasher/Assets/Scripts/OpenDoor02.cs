using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor02 : MonoBehaviour
{

    public GameObject doors;
    public GameObject realDoor;
    public Animator KnightAnim;
    public GameObject DoorText;
    public GameObject NewRoom;
    public bool canPressP;
    // Start is called before the first frame update
    void Start()
    {
        //   KnightAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We are inside");
        if (other.gameObject.CompareTag("Player"))
        {
            canPressP = true;
            DoorText.SetActive(true);
           
            
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
            NewRoom.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("We are Outside");

        DoorText.SetActive(false);



    }
}
