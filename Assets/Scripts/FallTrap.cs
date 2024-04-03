using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrap : MonoBehaviour
{
    Rigidbody2D rg;
    // Start is called before the first frame update
    void Start()
    {
        rg= GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2")))
        {
           rg.isKinematic = false;
        }

    }

}
