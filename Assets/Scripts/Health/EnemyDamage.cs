using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth health1, health2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            health1.GetDamage(damage);


            //other.gameObject.GetComponent<playerHealth>.health = -20; ( khusc 11:52 trong vid)
            
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            health2.GetDamage(damage);


            //other.gameObject.GetComponent<playerHealth>.health = -20; ( khusc 11:52 trong vid)
           
        }

    }
}
