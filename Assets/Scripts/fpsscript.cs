using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.UI;
using TMPro;

public class fpsscript : MonoBehaviour
{

    public int frameRate;
    TextMeshProUGUI fpsText;

    void Start(){
        fpsText = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("getFps", 1, 1);

    }

    

    void getFps()
    {
        frameRate = (int)(1f / Time.unscaledDeltaTime);
        fpsText.text = Mathf.Round(frameRate).ToString();
    }
}
