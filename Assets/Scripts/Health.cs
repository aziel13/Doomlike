using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Health : MonoBehaviour
{
    //Base Class to hold common variables and methods related to health
    
    protected float health;
    [SerializeField]private float maxHealth;

    
    void Update()
    {
        health = Mathf.Clamp(health,0,maxHealth);
    }
    
    public void takeDamage(float damage)
    {
        health -= damage;
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
    }

    public float GetHealthFraction()
    {
        return health / maxHealth;
    }
}
