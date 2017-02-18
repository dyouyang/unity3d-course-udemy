using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int REPLAY_BUFFER_SIZE_IN_FRAMES = 100;
    private ReplayKeyFrame[] replayKeyFrames = new ReplayKeyFrame[REPLAY_BUFFER_SIZE_IN_FRAMES];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RecordReplayKeyFrames();	
	}

    private void RecordReplayKeyFrames() {
        int currentBufferIndex = Time.frameCount % REPLAY_BUFFER_SIZE_IN_FRAMES;
        replayKeyFrames[currentBufferIndex] = new ReplayKeyFrame(Time.time, transform.position, transform.rotation);
    }
}

/// <summary>
/// Key Frame to store position and rotation data for replay feature.
/// </summary>
public struct ReplayKeyFrame {

    private float frameTime;
    private Vector3 pos;
    private Quaternion rot;

    public ReplayKeyFrame (float time, Vector3 pos, Quaternion rot) {
        frameTime = time;
        this.pos = pos;
        this.rot = rot;
    }
}
