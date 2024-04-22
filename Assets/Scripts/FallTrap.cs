using System.Collections;
using UnityEngine;

public class FallTrap : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private float delayTime = 3f; // Thời gian trễ trước khi bẫy rơi (3 giây)

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.isKinematic = true; // Ban đầu, đặt Rigidbody là kinematic để bẫy không rơi ngay lập tức
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            StartCoroutine(ActivateTrapAfterDelay()); // Kích hoạt coroutine để rơi bẫy sau một thời gian trễ
        }
    }

    IEnumerator ActivateTrapAfterDelay()
    {
        yield return new WaitForSeconds(delayTime); // Chờ thời gian trễ
        rg.isKinematic = false; // Kích hoạt Rigidbody để bẫy rơi
    }
}