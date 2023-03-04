using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mr_Spikey : MonoBehaviour
{
    // public Transform startMarker;
    // public Transform endMarker;
    // public float speed = 1.0F;
    // private float startTime;
    // private float journeyLength;

    // void Start() {
    //     startTime = Time.time;
    //     journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    // }

    // void Update() {
    //     float distCovered = (Time.time - startTime) * speed;
    //     float fracJourney = distCovered / journeyLength;
    //     transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    // }

    //  public Transform startMarker;
    // public Transform endMarker;
    // public float speed = 1.0F;
    // private float startTime;
    // private float journeyLength;

    // void Start() {
    //     startTime = Time.time;
    //     journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    // }

    // void Update() {
    //     float distCovered = (Time.time - startTime) * speed;
    //     float fracJourney = distCovered / journeyLength;
    //     transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

    //     if (fracJourney >= 1.0f) {
    //         // If object has reached end point, set its position to start point and reset startTime
    //         transform.position = startMarker.position;
    //         startTime = Time.time;
    //     }
    // }

    //  public Transform startMarker;
    // public Transform endMarker;
    // public float speed = 1.0F;
    // private float startTime;
    // private float journeyLength;

    // void Start() {
    //     startTime = Time.time;
    //     journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    // }

    // void Update() {
    //     float distCovered = (Time.time - startTime) * speed;
    //     float fracJourney = distCovered / journeyLength;
    //     transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

    //     if (fracJourney >= 1.0f) {
    //         // If object has reached end point, set its position to start point and reset startTime
    //         // transform.position = startMarker.position;
    //         transform.position = Vector3.Lerp(startMarker.position, startMarker.position, fracJourney);
    //         startTime = Time.time;
    //     }
    // }


    public Transform[] points;
    public float speed = 1.0f;
    public float pauseTime = 0.5f;
    private int currentPoint = 0;
    private bool isMoving = true;
    private float timeSincePaused;

    void Update() {
        if (isMoving) {
            MoveToNextPoint();
        } else {
            PauseAtCurrentPoint();
        }
    }

    void MoveToNextPoint() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, step);
        
        if (transform.position == points[currentPoint].position) {
            isMoving = false;
            timeSincePaused = Time.time;
        }
    }

    void PauseAtCurrentPoint() {
        if (Time.time - timeSincePaused >= pauseTime) {
            currentPoint = (currentPoint + 1) % points.Length;
            isMoving = true;
        }
    }
}
