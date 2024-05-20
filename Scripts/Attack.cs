using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public int attackDamage = 10;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Attack");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Robot Attack");
            PlayerDeath playerHealth = other.GetComponent<PlayerDeath>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                //Destroy(gameObject);
            }
        }
    }
}
