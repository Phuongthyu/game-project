using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible2 : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player2")
        {
            collision.GetComponent<PlayerHealth>().AddHealth((int)healthValue);
            gameObject.SetActive(false);
        }
    }
}
