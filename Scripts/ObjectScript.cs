using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{

    public float objectHealth = 100f;

    public void objectHitDamage(float amount)
    {
        objectHealth -= amount;

        if (objectHealth <= 0f)
        {
            //destroy
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
