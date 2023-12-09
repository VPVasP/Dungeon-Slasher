using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManagers : MonoBehaviour
{
   // public GameObject PauseButton1;
    public AudioSource backMusic; //our current music
    public AudioSource PauseSound;//our pause music
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    [SerializeField] private int i;
    public void Start()
    {
        pauseMenuUi.SetActive(false);
    }
  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused) Pause();//if game is not paused we pause else we Resume with the same key
            else Resume();
            
        }
    }
    public void Resume()
    {
   
        backMusic.Play();//we play our normal music
        PauseSound.Stop();//we stop our pause music
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f; //we set the scasle of time to 1
        GameIsPaused = false;
        Cursor.visible = false;//we set the cursor to being visible to false
        PlayerController.instance.enabled = true;//we enable the movement
    }
   public  void Pause()
    {

        PlayerController.instance.enabled = false;//we disable our movement
        Cursor.visible = true;
        backMusic.Stop();
        PauseSound.Play();
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
