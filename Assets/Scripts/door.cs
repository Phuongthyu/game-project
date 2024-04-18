using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public bool locked;
    public bool keyPickedUp;

    private Animator anim;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        locked = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (!locked && distance < 0.5f)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key") && keyPickedUp)
        {
            anim.SetTrigger("Open");
            locked = false;
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f); // Thời gian chờ trước khi load scene mới (có thể điều chỉnh)
        SceneManager.LoadScene("Level_2"); // Thay "TênSceneMới" bằng tên của scene mới
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key") && keyPickedUp)
        {
            locked = true;
        }
    }
}
