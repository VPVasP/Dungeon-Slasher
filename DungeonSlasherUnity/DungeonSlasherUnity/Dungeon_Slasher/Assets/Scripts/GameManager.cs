using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerCanvas;
    private IEnumerator coroutine; //refrence to our coroutine
    public GameObject StartMonologue; //the gameobject
    public float seconds = 2f; //our float seconds
    public KnightMovement ourMove;//refrence to our movement
    public Pause Pause;
    void Start()
    {
        Pause.enabled = false;
        PlayerCanvas.SetActive(false);//we set it false at the start
        ourMove.enabled = false;//we disable our movement
       StartMonologue.SetActive(true);//we set it false
        coroutine = StartEnumerator(2f);//we say that the startenumator is equal to coroutine and the time 2 seconds
        StartCoroutine(coroutine);//we call the coroutine
    }

    IEnumerator StartEnumerator(float seconds)
    {
        yield return new WaitForSeconds(seconds);//we wait for specific time
        StartMonologue.SetActive(false);//we disable the gameobject
        ourMove.enabled = true;//we enable our movement
        PlayerCanvas.SetActive(true);
        Pause.enabled = true;
    }
}
