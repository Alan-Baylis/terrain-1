using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class LookY : MonoBehaviour {

    [SerializeField] float sensitivityY;
    public float minimumY = -30F;
    public float maximumY = 30F;
    [SerializeField]float rotationY = 0F;
    PlayerControl playerControl;

    void Start ()
    {
        playerControl = GetComponentInParent<PlayerControl>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (rotationY >= 0.1)
        {
            Debug.Log("CameraMoves");
        }
        //print(playerControl.state.ThumbSticks.Right.Y);
        rotationY += playerControl.state.ThumbSticks.Right.Y * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
	}
}
