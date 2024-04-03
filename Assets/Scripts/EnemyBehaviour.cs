using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{

    public GameObject ponintA;
    public GameObject ponintB;
    private Rigidbody2D rd;
    private Transform currentPoint;
    private Animator animator;
    public float speed;
    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = ponintB.transform;
        animator.SetBool("isRunning", true);
    }
    private void Update()
    {
     Vector2 point = currentPoint.position - transform.position;
      if(currentPoint = ponintB.transform) 
        {
            rd.velocity =new Vector2(speed, 0);
        }
        else
        {
            rd.velocity = new Vector2(-speed, 0);
        }
      if(Vector2.Distance(transform.position, currentPoint.position) < 5f && currentPoint == ponintB.transform) 
        {
            flip();
            currentPoint = ponintA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 5f && currentPoint == ponintA.transform)
        {
            flip();
            currentPoint = ponintB.transform;
        }
    }
    private void flip()
    {
       Vector3 localScale = transform.localScale;
        localScale.x = -1;
        transform.localScale = localScale;  
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(ponintA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(ponintB.transform.position, 0.5f);
        Gizmos.DrawLine(ponintA.transform.position, ponintB.transform.position);

    }
}
