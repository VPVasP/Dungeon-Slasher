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
    public bool isDead;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private GameObject[] playerMeshes;
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
        if (health <= 0 && !isDead)
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
        isDead = true;
        healthText.enabled = false;
        PlayerController.instance.enabled = false;
        deathScreen.SetActive(true);
        foreach (GameObject playermeshesObject in playerMeshes)
        {
            playermeshesObject.SetActive(false);
        }

        anim.SetTrigger("Dead");
        Vector3 newPos = new Vector3(0f, 3f, 0f);
        Instantiate(deathEffect, transform.position + newPos, Quaternion.identity);

        Invoke("RestartScene", 3f);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene("Game");
    }
  
}
