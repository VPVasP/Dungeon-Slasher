using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject openDoorText;
    public GameObject[] rooms;
    public Transform spawnRoomPosition;
        private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We are inside");
        if (other.gameObject.CompareTag("Player")) // if tag is player
        {
            openDoorText.SetActive(true);//we set our tag to true
            Instantiate(rooms[Random.Range(0, rooms.Length)], spawnRoomPosition.position, Quaternion.identity);

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
     
        }
    }
   
}

