using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerHP;
    public int currHP;
    public Healthbar healthBar;
    public static bool GameOver;
    

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        currHP = PlayerHP;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver) 
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void GetDamage(int damage) 
    {
       

            currHP -= damage;
            healthBar.SetHealth(currHP);
            if (currHP <= 0)
            {
                GameOver = true;
            }
        
    }

    public void AddHealth(int value)
    {
        currHP += value;
        healthBar.SetHealth(currHP);
    }
}
