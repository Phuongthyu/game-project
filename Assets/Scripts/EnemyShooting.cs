using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    // Thời gian giữa các lần bắn
    public float timeBetweenShots = 1.0f; 
    private float timer;
    private GameObject player1;
    private GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player1.transform.position);
        float distance2 = Vector2.Distance(transform.position, player2.transform.position);
        Debug.Log(distance);
        Debug.Log(distance2);

        // khoang cach lai gan dan se dc ban và hết thời gian giữa các lần bắn
        if (distance < 200 || distance2 < 200)
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenShots)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
