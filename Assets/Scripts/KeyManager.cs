using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject door;

    public bool isPickedUp;
    private Vector2 vel;
    public float smoothTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            Vector3 offset = new Vector3(0, 1.7f, 0);
            transform.position = Vector2.SmoothDamp(transform.position, player1.transform.position + offset, ref vel, smoothTime);
            transform.position = Vector2.SmoothDamp(transform.position, player2.transform.position + offset, ref vel, smoothTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player1") && !isPickedUp || other.gameObject.CompareTag("Player2") && !isPickedUp)
        {
            isPickedUp = true;
            door.GetComponent<door>().keyPickedUp = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 1, 0.5f );
        Gizmos.DrawLine(transform.position, door.transform.position);
    }
}
