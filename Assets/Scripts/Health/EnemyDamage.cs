using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth health1, health2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player1"))
        {
            health1.GetDamage(damage);
        }
        if (collision.gameObject.tag.Equals("Player2"))
        {
            health2.GetDamage(damage);
        }
    }
}
