using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class redshot : MonoBehaviour
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
    public bool chosen;
    public bool pause;
    public Transform player;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Awake()
    { 
        moveSpeed = 1f;
        pause = false;
        chosen = false;
        first = true;
        start = false;
        gameObject.GetComponent<Renderer>().enabled = true;
        time = 0;
        alive = true;
        recieved = false;
        miss = true;
        camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;

        Vector2 pos = transform.position;
        pos.y = minY * 10 / 9;
        pos.x = minX * 10 / 9;
        transform.position = pos;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "main")
        {
            start = false;
            GameObject shooter = GameObject.Find("shooter");
            shooter playerScript = shooter.GetComponent<shooter>();
            playerScript.alive = false;

            GameObject square = GameObject.Find("Square");
            mousemve squareScript = square.GetComponent<mousemve>();
            squareScript.alive = false;

            GameObject snitch = GameObject.Find("snitch");
            snitch snitchScript = snitch.GetComponent<snitch>();
            snitchScript.alive = false;

            GameObject scoretxt = GameObject.Find("score text");
            scorescript scoreScript = scoretxt.GetComponent<scorescript>();
            scoreScript.alive = false;

            GameObject purpshoot = GameObject.Find("purpshooter");
            purpshoot purpShootScript = purpshoot.GetComponent<purpshoot>();
            purpShootScript.alive = false;
            purpshoot.GetComponent<Renderer>().enabled = false;

            GameObject secondpurpshooter = GameObject.Find("secondpurpshooter");
            secondpurpshoot secondpurpShootScript = secondpurpshooter.GetComponent<secondpurpshoot>();
            secondpurpShootScript.alive = false;
            secondpurpshooter.GetComponent<Renderer>().enabled = false;

            gameObject.GetComponent<Renderer>().enabled = false;

        }
        else if (collision.gameObject.tag == "line")
        {

            if (first)
            {
                GameObject ParticleSystem = GameObject.Find("Particle System Red");
                ParticleSystem.transform.position = transform.position;
                ParticleSystem.GetComponent<ParticleSystem>().Play();
                first = !first;
            }
            else
            {
                GameObject ParticleSystem = GameObject.Find("Particle System Red Sec");
                ParticleSystem.transform.position = transform.position;
                ParticleSystem.GetComponent<ParticleSystem>().Play();
                first = !first;
            }

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

            }

            moveSpeed = Random.Range(1, 3);

            transform.position = pos;

            pause = true;
            StartCoroutine(pauser());


        }
    }

    IEnumerator pauser()
    {
        if(time > 75){
            yield return new WaitForSeconds(Random.Range(3, 15));
            pause = false;
        }else{
            yield return new WaitForSeconds(Random.Range(2, 6));
            pause = false;
        }
        


    }


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 55)
        {
            start = true;
        }

        


        if (start & alive & !pause)
        {
            GameObject square = GameObject.Find("Square");
            Vector3 direction = square.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            if (time < 55)
            {
                moveSpeed = Random.Range(1, 3);
            }else if(time < 70){
                moveSpeed = Random.Range(2, 4);
            }else if(time < 105){
                moveSpeed = Random.Range(3, 5);
            }else{
                moveSpeed = Random.Range(4, 6);
            }

        }

    }

    private void FixedUpdate()
    {
        if (start & alive & !pause) {
            moveCharacter(movement);
        }
        
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * 4 * Time.deltaTime));
    }

}

