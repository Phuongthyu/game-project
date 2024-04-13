using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public static StarManager instance;

    private int stars ;
    [SerializeField] private TMP_Text starsDisplay;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }    
    }

    private void OnGUI()
    {
        starsDisplay.text = stars.ToString();
    }

    public void ChangeStars(int amount)
    {
        stars += amount;
    }    
}
