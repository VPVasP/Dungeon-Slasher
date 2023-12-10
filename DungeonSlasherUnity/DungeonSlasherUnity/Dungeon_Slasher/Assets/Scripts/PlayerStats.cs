using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public TextMeshProUGUI healthText;
    private Animator anim;
    public GameObject deathScreen;
    private IEnumerator coroutine; //refrence to our coroutine
    private void Start()
    {
        health = 100;
        anim = GetComponent<Animator>();
        healthText.text = "Health: " + health.ToString();
        health = Mathf.Clamp(health, 0, 100);
    }
    private void Update()
    {
        health = Mathf.Clamp(health, 0, 100);
        if (health <= 0)
        {
            Die();
        }
    }
    public void LoseHealth(float healthLoss)
    {
        health -=healthLoss;
        healthText.text = "Health: " + health.ToString();
    }
    public void Die()
    {
        healthText.enabled = false;
        PlayerController.instance.enabled = false;
        anim.SetTrigger("Dead"); //we play the death animation
        deathScreen.SetActive(true); //we set active the death panel
        coroutine = DelayScene(1f);//we say that the DelayScene is equal to coroutine and the time 2 seconds
        StartCoroutine(coroutine);//we call the coroutine
    }
    IEnumerator DelayScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);//we wait for specific time
        SceneManager.LoadScene("Game");
    }
}
