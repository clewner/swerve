using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerazoom : MonoBehaviour
{
    public bool ZoomActive;

    public Vector3[] Target;

    public Camera Cam;

    public float Speeed;

    void Start() {
        Cam = Camera.main;
    }

    public void LateUpdate() {
        if (ZoomActive)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 4.6f, Speeed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, Target[1], Speeed);

        }
        else {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 6.863174f, Speeed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, Target[0], Speeed);

        }
    
    }


}
