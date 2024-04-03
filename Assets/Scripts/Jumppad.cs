using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{

    public float bounce = 20f;
   

    //phát hiện va chạm giữa bậc nhảy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2")))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }    
    }


}
