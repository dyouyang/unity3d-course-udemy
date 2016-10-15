using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private float startTime;
    private Vector3 dragStart;

    // Use this for initialization
    void Start () {
        ball = GetComponent<Ball> ();
	}
	
    public void OnDragStart() {
        startTime = Time.time;
        dragStart = Input.mousePosition;
    }

    public void OnDragEnd() {
        float timeDiff = Time.time - startTime;
        Vector3 drag = Input.mousePosition - dragStart;

        // Velocity is distance / time. Y value of drag difference is used for
        // ball's Z velocity down the lane.
        ball.launchBall(new Vector3(drag.x / timeDiff, 0, drag.y / timeDiff));
    }
}
