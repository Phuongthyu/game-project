using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            collision.GetComponent<PlayerHealth>().AddHealth((int)healthValue);
            gameObject.SetActive(false);
        }
    }
}
