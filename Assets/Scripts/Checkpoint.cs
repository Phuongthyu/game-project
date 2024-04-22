using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            // Lưu vị trí checkpoint khi nhân vật đi qua
            other.GetComponent<PlayerHealth>().respawnPosition = transform.position;
        }
    }
}

