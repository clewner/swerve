using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomright : MonoBehaviour
{

    private float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;

        Vector3 pos = transform.position;
        pos.x = maxX;
        pos.y = minY;

        transform.position = pos;
    }



    // Update is called once per frame
    void Update()
    {

    }
}

