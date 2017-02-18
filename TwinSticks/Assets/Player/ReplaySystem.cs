using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int REPLAY_BUFFER_SIZE_IN_FRAMES = 100;
    private ReplayKeyFrame[] replayKeyFrames = new ReplayKeyFrame[REPLAY_BUFFER_SIZE_IN_FRAMES];

    private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        RecordReplayKeyFrames();	
	}

    private void RecordReplayKeyFrames() {
        rigidBody.isKinematic = false;
        int currentBufferIndex = Time.frameCount % REPLAY_BUFFER_SIZE_IN_FRAMES;
        replayKeyFrames[currentBufferIndex] = new ReplayKeyFrame(Time.time, transform.position, transform.rotation);
    }

    private void PlaybackReplay() {
        rigidBody.isKinematic = true;
        int currentBufferIndex = Time.frameCount % REPLAY_BUFFER_SIZE_IN_FRAMES;
        transform.position = replayKeyFrames[currentBufferIndex].Pos;
        transform.rotation = replayKeyFrames[currentBufferIndex].Rot;
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

    public Vector3 Pos {
        get {
            return pos;
        }

        set {
            pos = value;
        }
    }

    public Quaternion Rot {
        get {
            return rot;
        }

        set {
            rot = value;
        }
    }
}
