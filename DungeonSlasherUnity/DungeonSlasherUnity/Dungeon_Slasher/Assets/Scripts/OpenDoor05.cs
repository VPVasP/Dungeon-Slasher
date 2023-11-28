using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor05 : MonoBehaviour
{
    public GameObject ExitDungeon;
    private void OnTriggerEnter(Collider other)
    {
        ExitDungeon.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Menu01");
        }
    }
}
