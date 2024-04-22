using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScenceMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Kiểm tra nếu người chơi nhấn phím số 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Chuyển đến Scene2
            SceneManager.LoadScene("Main Menu");
        }
    }
}
