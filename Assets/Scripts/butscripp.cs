using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class butscripp : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = true;   
    }

    // Update is called once per frame
    void Update()
    {
        button.interactable = true;
    }
}
