using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scorescript : MonoBehaviour
{
    public static string scoreValue = "0";
    public float time = 0;
    TextMeshProUGUI scoreText;
    public bool alive = true;
    // Start is called before the first frame update


    void Start()
    {
        alive = true;
        time = 0;
        scoreValue = "0";
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            GameObject shooter = GameObject.Find("shooter");
            shooter playerScript = shooter.GetComponent<shooter>();

            GameObject snitch = GameObject.Find("snitch");
            snitch snitchScript = snitch.GetComponent<snitch>();

            time += Time.deltaTime;

            scoreValue = Mathf.Round(time / 2 + playerScript.score + snitchScript.score).ToString();

            scoreText.text = scoreValue;
            //scoreText.text = Mathf.Round(time).ToString();
        }
    }
}
