using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class secondpurpshoot : MonoBehaviour
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
    public float time = 0;
    float camDistance;
    Vector2 bottomCorner;
    Vector2 topCorner;
    public bool alive = true;
    public bool directright;
    public bool first;
    public bool secphase = false;

    // Start is called before the first frame update
    void Awake()
    {
        secphase = false;
        first = true;
        start = false;
        gameObject.GetComponent<Renderer>().enabled = true;
        time = 0;
        alive = true;


        recieved = false;
        miss = true;
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.rotation = 45f;

        camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

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


        rigidBody2D.rotation = (Mathf.Atan(Mathf.Abs(targetPoss.y - pos.y) / Mathf.Abs(targetPoss.x - pos.x))) * 180 / Mathf.PI - 90;
        directright = true;
        multiplier = Random.Range(4, 7);



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "main")
        {
            start = false;
            GameObject shooter = GameObject.Find("shooter");
            shooter playerScript = shooter.GetComponent<shooter>();
            playerScript.alive = false;

            GameObject snitch = GameObject.Find("snitch");
            snitch snitchScript = snitch.GetComponent<snitch>();
            snitchScript.alive = false;

            GameObject square = GameObject.Find("Square");
            mousemve squareScript = square.GetComponent<mousemve>();
            squareScript.alive = false;

            GameObject scoretxt = GameObject.Find("score text");
            scorescript scoreScript = scoretxt.GetComponent<scorescript>();
            scoreScript.alive = false;

            GameObject purpshoot = GameObject.Find("purpshooter");
            purpshoot purpShootScript = purpshoot.GetComponent<purpshoot>();
            purpShootScript.alive = false;
            purpshoot.GetComponent<Renderer>().enabled = false;

            GameObject redshot = GameObject.Find("redshot");
            redshot redshotScript = redshot.GetComponent<redshot>();
            redshotScript.alive = false;
            redshot.GetComponent<Renderer>().enabled = false;

            gameObject.GetComponent<Renderer>().enabled = false;

        }
        else if (collision.gameObject.tag == "line")
        {
            pos.y = targetPoss.y;
            pos.x = targetPoss.x;

            if (first)
            {
                GameObject ParticleSystem = GameObject.Find("Particle System Thir");
                ParticleSystem.transform.position = transform.position;
                ParticleSystem.GetComponent<ParticleSystem>().Play();
                first = !first;
            }
            else
            {
                GameObject ParticleSystem = GameObject.Find("Particle System Four");
                ParticleSystem.transform.position = transform.position;
                ParticleSystem.GetComponent<ParticleSystem>().Play();
                first = !first;
            }

            transform.position = pos;



        }
    }




    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > 75){
            secphase = false;
            start = true;
        }else if(time > 55){
            secphase = true;
        }else if (time > 40) {
            start = true;
            secphase = false;
            
        }

        

        if (start & alive)
        {

            Vector2 pos = transform.position;
            pos = Vector2.MoveTowards(pos, targetPoss, speed * Time.deltaTime * Mathf.Abs(multiplier));

            if (pos == targetPoss)
            {

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

                    if (time < 60)
                    {
                        multiplier = Random.Range(4, 7);
                    }
                    else if (time < 75)
                    {
                        multiplier = Random.Range(6, 10);

                    }else{
                        multiplier = Random.Range(8, 12);
                    }
                    miss = true;
                    recieved = false;
                    directright = true;
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

                    if (time < 60)
                    {
                        multiplier = Random.Range(4, 7);
                    }
                    else if (time < 75)
                    {
                        multiplier = Random.Range(6, 10);

                    }else{
                        multiplier = Random.Range(8, 12);
                    }
                    miss = true;
                    recieved = false;
                    directright = false;
                    
                }
                if(secphase){
                    start = false;
                }
            }


            transform.position = pos;
            if (directright)
            {
                rigidBody2D.rotation = (Mathf.Atan(Mathf.Abs(targetPoss.y - pos.y) / Mathf.Abs(targetPoss.x - pos.x))) * 180 / Mathf.PI - 90;
            }
            else
            {
                rigidBody2D.rotation = -1 * (Mathf.Atan(Mathf.Abs(targetPoss.x - pos.x) / Mathf.Abs(targetPoss.y - pos.y))) * 180 / Mathf.PI - 180;
            }
        }

    }

}

