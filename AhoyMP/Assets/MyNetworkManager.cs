using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {


    // NetworkManager's StartHost is not exposed to scripts, so call with this method.
    public new void StartHost() {
        base.StartHost();
        Debug.Log(Time.time + " : Starting host...");
    }

    public override void OnStartHost() {
        base.OnStartHost();
        Debug.Log(Time.time + " : Host started");
    }

    public override void OnStartClient(NetworkClient client) {
        base.OnStartClient(client);
        Debug.Log(Time.time + " : Client started, connect requested...");
    }

    public override void OnClientConnect(NetworkConnection conn) {
        base.OnClientConnect(conn);
        Debug.Log(Time.time + " : Client connected, IP : " + conn.address);
    }
}
