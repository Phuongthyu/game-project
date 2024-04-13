using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth1;
    [SerializeField] private Health playerHealth2;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    // Start is called before the first frame update
    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth1.currentHealth / 10;
        totalhealthBar.fillAmount = playerHealth2.currentHealth / 10;
    }

    // Update is called once per frame
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth1.currentHealth / 10;
        currenthealthBar.fillAmount = playerHealth2.currentHealth / 10;
    }
}
