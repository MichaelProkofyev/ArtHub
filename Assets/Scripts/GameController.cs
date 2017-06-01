using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonComponent<GameController> {

    public Transform cameraRig;

    public Transform mainCamera;

    public Transform teleportLocation;
    
    public void ResetPlayerPosition () {
        Vector3 startRigPostion = teleportLocation.position - mainCamera.localPosition;
        cameraRig.position = new Vector3(startRigPostion.x, 0, startRigPostion.z);
    }

	// Use this for initialization
	void Start () {
        ResetPlayerPosition();
    }
	
	void Update () {

	}
}
