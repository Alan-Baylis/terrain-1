using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class LookX : MonoBehaviour {

    [SerializeField] float sensitivity = 5.0f;

    PlayerIndex playerIndex;
    GamePadState state;
   
    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
        GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
        state = GamePad.GetState(playerIndex);
        transform.Rotate(0, state.ThumbSticks.Right.X * sensitivity, 0);
	}
}
