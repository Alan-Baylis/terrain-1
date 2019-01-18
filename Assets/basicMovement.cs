//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class basicMovement : MonoBehaviour
//{
//    CharacterController varController;
//    [SerializeField] float jumpSpeed = 20.0f;
//    [SerializeField] float gravity = 1.0f;
//    float yVelocity = 0.0f;
//    [SerializeField] float moveSpeed = 5.0f;


//    // Start is called before the first frame update
//    void Start()
//    {
//        varController = GetComponent<CharacterController>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        float X = Input.GetAxis("JoyStickX" + playerNum);
//        Vector3 rot = transform.localEulerAngles;
//        rot.y += X * 5;
//        transform.localEulerAngles = rot;

//        float h = state.ThumbSticks.Left.X;//Input.GetAxis("Horizontal" + playerNum);
//        float v = state.ThumbSticks.Left.Y;//Input.GetAxis("Vertical" + playerNum);
//        Vector3 direction = new Vector3(h, 0, v);
//        Vector3 velocity = direction * moveSpeed;
//        if (varController.isGrounded)
//        {
//            Debug.Log("On Ground");
//            if (state.Buttons.Y == ButtonState.Pressed)
//            {
//                Debug.Log("Jumped");
//                yVelocity = jumpSpeed;
//            }
//        }
//        else
//        {
//            yVelocity -= gravity;
//        }
//        velocity.y = yVelocity;
//        velocity = transform.TransformDirection(velocity);
//        varController.Move(velocity * Time.deltaTime);
//    }
//}
