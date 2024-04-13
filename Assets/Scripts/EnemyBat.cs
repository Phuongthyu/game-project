using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
    }
}

