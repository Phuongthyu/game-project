using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    private Rigidbody2D rb;
    private Rigidbody2D rb2;
    public PlayerHealth health1, health2;
    public float force;
    public int damage;
    private float timer;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb2 = GetComponent<Rigidbody2D>();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        Vector3 direction1 = player1.transform.position - transform.position;
        rb.velocity = new Vector2(direction1.x,direction1.y).normalized  * force;
        
        Vector3 direction2 = player2.transform.position - transform.position;
        rb2.velocity = new Vector2(direction2.x,direction2.y).normalized  * force;

        float rot1 = Mathf.Atan2(-direction1.x, -direction1.y) * Mathf.Rad2Deg;
        float rot2 = Mathf.Atan2(-direction2.x, -direction2.y) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(0, 0, rot1 - 90);
        transform.rotation = Quaternion.Euler(0, 0, rot2 - 90);

    }

   

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;

        //nếu viên đạn ở lâu hơn số thời gian đưa ra thì viên đạn sẽ bị phá hủy
       // if (timer > 15)
       // {
            //Destroy(gameObject);
       // }
    }

    // viên đạn sẽ bị phá hủy nếu va chạm với người chơi
     private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.CompareTag("Player1") )
         {
            health1.GetDamage(damage);
           

            //other.gameObject.GetComponent<playerHealth>.health = -20; ( khusc 11:52 trong vid)
            Destroy(gameObject);
         }
        if (other.gameObject.CompareTag("Player2"))
        {
            health2.GetDamage(damage);


            //other.gameObject.GetComponent<playerHealth>.health = -20; ( khusc 11:52 trong vid)
            Destroy(gameObject);
        }

    }
   

  
}
