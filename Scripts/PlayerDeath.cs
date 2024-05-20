using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath: MonoBehaviour
{
    [Header("Player Death")]
    public float maxHealth = 100f;
    private float currentHealth;
    public GameObject deathEffect;
    public bool isDead = false;

    public Animator anim;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Player initialized with health: " + currentHealth);
    }
    public void TakeDamage(float takeDamage)
    {

        if (isDead)
        {
            return;
        }

        Debug.Log("Take Damage");
        currentHealth -= takeDamage;
        Debug.Log("Player took damage: " + takeDamage + ", current health: " + currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Player is dying...");

        GetComponent<PlayerScript>().enabled = false;

        if (anim != null)
        {
            anim.SetTrigger("Death");
        }
        else
        {
            Debug.LogWarning("Animator component is missing.");
        }

        if (deathEffect != null)
        {
            GameObject effectt = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effectt);
        }

        //Destroy(gameObject, 2f);

        Debug.Log("Player Died");

        StartCoroutine(DestroyPlayerAfterDelay(2f));
        // Load the main menu scene after a delay to allow the death animation/effects to play
        StartCoroutine(LoadMainMenuAfterDelay(2f)); // 2 seconds delay
    }

    private IEnumerator DestroyPlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject, 3f); // Destroy the player object
    }

    private IEnumerator LoadMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //SceneManager.LoadScene("MenuScene"); // Replace "MainMenu" with the actual name of your main menu scene
    }
}
