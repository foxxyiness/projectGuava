using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{

    public Health healthToDisplay;
    public Text healthDisplay;
    void Update()
    {
        healthDisplay.text = healthToDisplay.currentHealth.ToString();
    }
}
