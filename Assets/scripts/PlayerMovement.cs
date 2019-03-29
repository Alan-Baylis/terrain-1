using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerMovement : MonoBehaviour {

    CharacterController charController;

    PlayerControl playerControl;

    [SerializeField] float jumpSpeed = 20.0f;
    [SerializeField] float gravity = 1.0f;
    float yVelocity = 0.0f;
    public int playerNum;

    [SerializeField] float moveSpeed = 5.0f;
    public float h;
    public float v;
    Animator anim;

	// Use this for initialization
	void Start () {
        charController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerControl = GetComponent<PlayerControl>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        h = playerControl.state.ThumbSticks.Left.X;
        v = playerControl.state.ThumbSticks.Left.Y;
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);

        Vector3 direction = new Vector3(h, 0, v);
        Vector3 velocity = direction * moveSpeed;

        if (charController.isGrounded)
        {
            if (playerControl.state.Buttons.Y == ButtonState.Pressed)
            {
                anim.SetTrigger("Jump");
                yVelocity = jumpSpeed;
            }
        }
        else
        {
            yVelocity -= gravity;
        }
        velocity.y = yVelocity;

        velocity = transform.TransformDirection(velocity);

        charController.Move(velocity * Time.deltaTime);

    }
}
