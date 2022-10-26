using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mousemve : MonoBehaviour
{
    Vector2 MinPos;
    Vector2 MaxPos;

    public float targetScale;
    public float timeToLerp = 0.25f;
    float scaleModifier = 1;

    public bool pause = false;
    Vector3 beginscale;

    public bool alive = true;
    public float Speed = 20;
    public float Radius = 4;


    public void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        alive = true;
        Vector2 Size = GetComponent<SpriteRenderer>().bounds.extents;
        MinPos = (Vector2)Camera.main.ViewportToWorldPoint(new Vector2(0, 0)) + Size;
        MaxPos = (Vector2)Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) + Size * -1;
        pause = false;
        beginscale = transform.localScale;
    }

    public void Update()
    {
        if (alive)
        {

            Vector2 mousePos = (Input.mousePosition);
            Vector2 targetPos = new Vector2(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y);


            targetPos.x = Mathf.Clamp(targetPos.x, MinPos.x, MaxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, MinPos.y, MaxPos.y);

            transform.position = Vector2.Lerp(transform.position, targetPos, Time.deltaTime * Speed * 10);
        }
        else {

            StartCoroutine(ExampleCoroutine());
            if (pause)
            {
                StartCoroutine(LerpFunction(3, 0.2f));
                StartCoroutine(after());
            }
            

        }
    }

    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(1);
        pause = true;

    }

    IEnumerator after()
    {

        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("restart");

    }

    IEnumerator LerpFunction(float endValue, float duration)
    {
        float time = 0;
        float startValue = scaleModifier;
        Vector3 startScale = transform.localScale;

        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }
        
    }
}