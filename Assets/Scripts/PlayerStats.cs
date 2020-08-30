using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float currentHealth;
    public float Health;
    public DeathScreen deathscreen;
    public Text health;
    public bool burning;
    
    void Start()
    {
        Health = 100;
        currentHealth = Health;
        burning = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "LavaPlate")
        {
            burning = true;
            StartCoroutine(BurningCoroutine());
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "LavaPlate")
        {
            burning = false;
        }
    }

    IEnumerator BurningCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        currentHealth = currentHealth - 5;
        if(burning == true)
        {
            StartCoroutine(BurningCoroutine());
        }
    }

    void Update()
    {
        health.text = "HP: " + currentHealth.ToString();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("You Died!");
        deathscreen.ToggleEndMenu();
    }
}
