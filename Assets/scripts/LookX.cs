using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class LookX : MonoBehaviour {

    [SerializeField] float sensitivity = 5.0f;
    PlayerControl playerControl;

   
    // Use this for initialization
	void Start ()
    {
        playerControl = GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        transform.Rotate(0, playerControl.state.ThumbSticks.Right.X * sensitivity, 0);
	}
}
