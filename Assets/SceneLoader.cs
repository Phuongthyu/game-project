using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Kiểm tra nếu người chơi nhấn phím số 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Chuyển đến Scene2
            SceneManager.LoadScene("Level_1");
        }
    }
}