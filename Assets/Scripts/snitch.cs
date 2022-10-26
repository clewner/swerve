using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snitch : MonoBehaviour
{
    public float Speed = 2;
    private float minX, maxX, minY, maxY;
    Vector2 targetPoss;
    Vector2 pos;
    public int speed = 2;
    public bool top;
    public float startx;
    public float starty;
    public float multiplier;
    public Rigidbody2D rigidBody2D;
    public bool miss;
    public bool recieved;
    public bool start = false;
    public int score = 0;
    public float time = 0;
    public bool alive = true;
    public bool pause = true;

    // Start is called before the first frame update
    void Start()
    {
        pause = true;
        time = 0;
        start = false;
        score = 0;
        alive = true;

        recieved = false;
        miss = true;
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.rotation = 45f;

        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;

        Vector2 pos = transform.position;
        if (Random.Range(1, 3) == 1)
        {
            pos.y = Random.Range(minY, 0);
            pos.x = minX * 10 / 9;

        }
        else
        {
            pos.y = minY * 10 / 9;
            pos.x = Random.Range(minX, 0);
        }


        transform.position = pos;
        if (Random.Range(1, 3) == 1)
        {
            targetPoss = new Vector2(maxX * 5 / 4, Random.Range(minY * 1 / 3, maxY));
            top = false;
        }
        else
        {
            targetPoss = new Vector2(Random.Range(minX * 1 / 3, maxX), maxY * 5 / 4);
            top = true;
        }

        multiplier = Random.Range(9, 13);

        StartCoroutine(ExampleCoroutine());



    }

    void FixedUpdate()
    {
        if (start & alive)
        {
            rigidBody2D.rotation += 1.0f * Mathf.Pow(multiplier, 2);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (start & alive)
        {
            if (collision.gameObject.tag == "main")
            {
                miss = false;
                pos.y = targetPoss.y;
                pos.x = targetPoss.x;
                recieved = true;

                transform.position = pos;
                GameObject zoom = GameObject.Find("Zoom");
                camerazoom Camerazoom = zoom.GetComponent<camerazoom>();
                Camerazoom.ZoomActive = true;

                StartCoroutine(randomquar());
                score += 30;


            }
            else if (collision.gameObject.tag == "line")
            {
                if (recieved == false)
                {
                    pos.y = targetPoss.y;
                    pos.x = targetPoss.x;

                    GameObject ParticleSystem = GameObject.Find("Particle System Snitch");
                    ParticleSystem.transform.position = transform.position;
                    ParticleSystem.GetComponent<ParticleSystem>().Play();
                    transform.position = pos;
                    
                }


            }
        }
    }

    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(15);
        start = true;
        StartCoroutine(RandomWait());


    }

    IEnumerator RandomWait()
    {

        yield return new WaitForSeconds(Random.Range(10, 40));
        pause = false;


    }

    IEnumerator randomquar()
    {

        yield return new WaitForSeconds(0.2f);
        GameObject zoom = GameObject.Find("Zoom");
        camerazoom Camerazoom = zoom.GetComponent<camerazoom>();
        Camerazoom.ZoomActive = false;


    }


    // Update is called once per frame
    void Update()
    {

        if (start & alive & !pause)
        {

            Vector2 pos = transform.position;
            pos = Vector2.MoveTowards(pos, targetPoss, speed * Time.deltaTime * Mathf.Abs(multiplier));

            if (pos == targetPoss)
            {
                start = false;
                StartCoroutine(ExampleCoroutine());
                if (Random.Range(1, 3) == 1)
                {
                    if (Random.Range(1, 3) == 1)
                    {
                        pos.y = Random.Range(minY, 0);
                        pos.x = minX * 10 / 9;
                    }
                    else
                    {
                        pos.y = minY * 10 / 9;
                        pos.x = Random.Range(minX, 0);
                    }

                    if (Random.Range(1, 3) == 1)
                    {
                        targetPoss = new Vector2(maxX * 5 / 4, Random.Range(minY * 1 / 3, maxY));
                        top = false;
                    }
                    else
                    {
                        targetPoss = new Vector2(Random.Range(minX * 1 / 3, maxX), maxY * 5 / 4);
                        top = true;
                    }


                    multiplier = Random.Range(9, 13);
                    miss = true;
                    recieved = false;
                }
                else
                {
                    if (Random.Range(1, 3) == 1)
                    {
                        pos.y = Random.Range(0, maxY);
                        pos.x = maxX * 10 / 9;
                    }
                    else
                    {
                        pos.y = maxY * 10 / 9;
                        pos.x = Random.Range(0, maxX);
                    }

                    if (Random.Range(1, 3) == 1)
                    {
                        targetPoss = new Vector2(minX * 5 / 4, Random.Range(maxY * 1 / 3, minY));
                        top = false;
                    }
                    else
                    {
                        targetPoss = new Vector2(Random.Range(maxX * 1 / 3, minX), minY * 5 / 4);
                        top = true;
                    }

                    multiplier = Random.Range(9, 13);
                    miss = true;
                    recieved = false;
                }
                pause = true;
                StartCoroutine(RandomWait());
            }
            transform.position = pos;
        }

    }

}

