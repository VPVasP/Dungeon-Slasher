using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    private IEnumerator coroutine;//reference to our enumerator
    public GameObject StartMonologue;
    public float seconds = 2f;//our seconds
   
    private void OnTriggerEnter(Collider other)
    {
        
        StartMonologue.SetActive(true);
        coroutine = StartEnumerator(2f);//our coroutine is equal to this
        StartCoroutine(coroutine);//we start the coroutine
        
    }
    IEnumerator StartEnumerator(float seconds)
    { 
        yield return new WaitForSeconds(seconds);//we wait for a certain amount of time(our float seconds)

        StartMonologue.SetActive(false);
    }
}
