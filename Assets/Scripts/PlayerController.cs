using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayerController : MonoBehaviour {

    public VRTK_ControllerEvents rightController;
    // Use this for initialization
    void Start () {
        rightController.TouchpadPressed += ResetPosition;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
    
    }

    void ResetPosition (object sender, ControllerInteractionEventArgs args)
    {
        GameController.Instance.ResetPlayerPosition();
    }
}
