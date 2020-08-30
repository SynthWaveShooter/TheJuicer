using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int currHealth;
    public int maxHealth;

    public int currStamina;
    public int maxStamina;

    public bool isDead = false;

    public void CheckHealth()
    {
        if (currHealth >= maxHealth)
        {
            currHealth = maxHealth;
        }
        if (currHealth <= 0)
        {
            currHealth = 0;
            isDead = true;
        }
    }

    public void CheckStamina() 
    {
        if (currStamina >= maxStamina)
        {
            currStamina = maxStamina;
        }
        if(currStamina <= 0)
        {
            currStamina = 0;
        }
    }

    public virtual void Die()
    {
        //Override.
    }


}
// Author: Evan
//Video: https://www.youtube.com/watch?v=KoKDRY1n-cQ&list=PLKklF7YNi0lOM0C8r_L3JN3oTC6AY9iFE&index=12&t=0s
//Made at 6:36 Pm 6/1/2020