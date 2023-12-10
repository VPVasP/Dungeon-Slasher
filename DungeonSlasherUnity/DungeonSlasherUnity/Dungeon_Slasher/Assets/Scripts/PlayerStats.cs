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
        if (health <= 0)
        {
            Die();
        }
    }
    public void LoseHealth()
    {
        float randomLoseHealth = Random.Range(5,10);
        health -= randomLoseHealth;
    }
    public void Die()
    {
        healthText.enabled = true;
        this.enabled = false;
        anim.SetTrigger("Death"); //we play the death animation
        deathScreen.SetActive(true); //we set active the death panel
        coroutine = DelayScene(2f);//we say that the DelayScene is equal to coroutine and the time 2 seconds
        StartCoroutine(coroutine);//we call the coroutine
    }
    IEnumerator DelayScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);//we wait for specific time
        SceneManager.LoadScene("Game");
    }
}
