using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRabbit : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplosion;
    public GameObject ExporeEffect;
    public PlayerHealth health1, health2;
    public int damage;

    private void Update()
    {
       
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player1") || collision.gameObject.tag.Equals("Player2"))
        {
            health1.GetDamage(damage);
            health2.GetDamage(damage);
            Explosion();
        }
    }

    public void Explosion()
    {
        Instantiate(ExporeEffect, transform.position, Quaternion.identity);
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach (Collider2D colisionador in objetos)
        {
            Rigidbody rb2D = colisionador.GetComponent<Rigidbody>();
            if (rb2D != null)
            {
                Vector2 direccion = colisionador.transform.position - transform.position;
                float distancia = 1 + direccion.magnitude;
                float fuerzaFinal = fuerzaExplosion / distancia;
                rb2D.AddForce(direccion * fuerzaFinal);
            }
        }
        Destroy(gameObject);
    }
    

    //xem diện tích nổ
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
