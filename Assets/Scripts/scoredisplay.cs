using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoredisplay : MonoBehaviour
{
    TextMeshProUGUI scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GetComponent<TextMeshProUGUI>();
        scoreDisplay.text = scorescript.scoreValue;

        
    }

}
