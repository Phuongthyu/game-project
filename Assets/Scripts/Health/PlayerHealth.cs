using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerHP;
    public int currHP;
    public Healthbar healthBar;
    public Vector3 respawnPosition;
    private bool hasDiedOnce = false;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currHP = PlayerHP;
        healthBar.SetMaxHealth(PlayerHP);
        respawnPosition = transform.position; // Khởi tạo respawnPosition ban đầu
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            // Handle game over
            GameOver();
        }
    }

    public void GetDamage(int damage)
    {
        currHP -= damage;
        healthBar.SetHealth(currHP);

        if (currHP <= 0)
        {
            if (!hasDiedOnce)
            {
                // Respawn at checkpoint if this is the first death
                Respawn();
                hasDiedOnce = true;
            }
            else
            {
                // Set isDead to true to indicate game over on second death
                isDead = true;
            }
        }
    }

    // Function to handle respawn at checkpoint
    void Respawn()
    {
        // Respawn tại vị trí đã lưu từ điểm checkpoint
        transform.position = respawnPosition;
        currHP = PlayerHP;
        healthBar.SetHealth(currHP);
    }

    // Function to handle game over
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    // Function to add health
    public void AddHealth(int value)
    {
        currHP += value;
        // Ensure health doesn't exceed maximum health
        currHP = Mathf.Min(currHP, PlayerHP);
        healthBar.SetHealth(currHP);
    }
}