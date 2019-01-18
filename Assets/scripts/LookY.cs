using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class LookY : MonoBehaviour {

    [SerializeField] float sensitivityY;
    public float minimumY = -30F;
    public float maximumY = 30F;
    [SerializeField]float rotationY = 0F;

    PlayerIndex playerIndex;
    GamePadState state;

    void Start ()
    {
        
    }

	// Update is called once per frame
	void Update ()
    {
        state = GamePad.GetState(playerIndex);
        if (rotationY >= 0.1)
        {
            Debug.Log("CameraMoves");
        }
        print(state.ThumbSticks.Right.Y);
        rotationY += state.ThumbSticks.Right.Y * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
	}
}
