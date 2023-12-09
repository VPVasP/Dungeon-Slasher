using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject openDoorText;
    public GameObject[] rooms;
    public Vector3 spawnRoomPosition;
    [SerializeField] private bool hasEntered = false;
    public string[] dialogueSentences;
    private IEnumerator coroutine; //refrence to our coroutine
    private void Start()
    {
        openDoorText = GameObject.FindGameObjectWithTag("DoorText");
        openDoorText.GetComponent<Image>().enabled = false;
        openDoorText.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        spawnRoomPosition = this.transform.position + new Vector3(0, 0, 210);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We are inside");
        if (other.gameObject.CompareTag("Player") && !hasEntered) // if tag is player
        {
            openDoorText.GetComponent<Image>().enabled = true;
            openDoorText.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            Instantiate(rooms[Random.Range(0, rooms.Length)], spawnRoomPosition, Quaternion.identity);
            string randomSentence = dialogueSentences[Random.Range(0, dialogueSentences.Length)];
            GameManager.instance.StartMonologue.SetActive(true);//we set it false
            GameManager.instance.StartMonologue.GetComponentInChildren<TextMeshProUGUI>().text = randomSentence;
            this.GetComponent<Renderer>().enabled = false;
            coroutine = DisableTextEnumerator(2f);//we say that the startenumator is equal to coroutine and the time 2 seconds
            StartCoroutine(coroutine);//we call the coroutine
        }
    }
    private void OnTriggerExit(Collider other)
    {
        openDoorText.GetComponent<Image>().enabled = false;
        openDoorText.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        // GameManager.instance.StartMonologue.SetActive(false);//we set it false
        Destroy(this.gameObject, 3f);
    }

    IEnumerator DisableTextEnumerator(float seconds)
    {
        yield return new WaitForSeconds(seconds);//we wait for specific time
        GameManager.instance.StartMonologue.SetActive(false);
    }
}
