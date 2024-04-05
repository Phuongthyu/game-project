using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    Vector3 DesPoint;

    public GameObject Bridge;
    public Transform[] waypoints;
    int point;
    int pointAmount;
    int direction = 1;

    public float waitDuration;
    int speedMutiplier;

    Move move;
    Move2 move2;

    Rigidbody2D rigidbody2;
    Vector3 moveDirection;
    public void Awake()
    {
        move= GameObject.FindWithTag("Player1").GetComponent<Move>();
        move2 = GameObject.FindWithTag("Player2").GetComponent<Move2>();
        rigidbody2 = GetComponent<Rigidbody2D>();
        waypoints = new Transform[Bridge.transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = Bridge.transform.GetChild(i).gameObject.transform;
        }

    }
    private void Start()
    {
        DirectionCaculate();
        pointAmount = waypoints.Length;
        point = 0;
        DesPoint = waypoints[point].transform.position;
    }
    private void Update()
    {
        
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, DesPoint, step);

        if (transform.position == DesPoint)
        {
            NextPoint();
            DirectionCaculate();
        }
    }
    void NextPoint()
    {
        point += direction;

        // Kiểm tra xem point có vượt quá giới hạn của mảng không
        if (point >= pointAmount || point < 0)
        {
            direction *= -1; // Đảo hướng di chuyển
            point = Mathf.Clamp(point, 0, pointAmount - 1); // Đảm bảo point nằm trong giới hạn của mảng
        }

        DesPoint = waypoints[point].transform.position;
    }
    IEnumerable WaitPoint()
    {
        speedMutiplier = 0;
        yield return new WaitForSeconds(waitDuration);
        speedMutiplier = 1;
    }
    private void FixedUpdate()
    {
            rigidbody2.velocity = moveDirection * speed;
    }

   
   void DirectionCaculate()
    {
        moveDirection = (DesPoint - transform.position).normalized;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2") || collision.CompareTag("Player1") && collision.CompareTag("Player2"))
        {
           //move.isOnPlatform = true;
            //move2.isOnPlatform = true;
            //move.platform = rigidbody2;
           // move2.platform = rigidbody2;
           collision.transform.SetParent(this.transform);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2") || collision.CompareTag("Player1") && collision.CompareTag("Player2"))
        {
            //move.isOnPlatform = false;

            //move2.isOnPlatform = false;
            collision.transform.SetParent(null); 
        }
    }


}
