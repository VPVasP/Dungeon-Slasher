using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;//we make the cursor visible 
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//our current scene +1

    }
    public void QuitGame()
    {
        Application.Quit();//we quit the game
    }
}


