using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
   // public GameObject PauseButton1;
    public AudioSource backMusic; //our current music
    public AudioSource PauseSound;//our pause music
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    public KnightMovement ourMove;//reference to our music
    [SerializeField] private int i;
    public void Start()
    {
        pauseMenuUi.SetActive(false);
    }
  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused) PauseThis();//if game is not paused we pause else we resume with the same key
            else resume();
            
        }
       


    }
    public void resume()
    {
   
        backMusic.Play();//we play our normal music
        PauseSound.Stop();//we stop our pause music
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f; //we set the scasle of time to 1
        GameIsPaused = false;
        Cursor.visible = false;//we set the cursor to being visible to false
        ourMove.enabled = true;//we enable our movement
    }
   public  void PauseThis()
    {
      
        ourMove.enabled = false;
        Cursor.visible = true;
        backMusic.Stop();
        PauseSound.Play();
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
