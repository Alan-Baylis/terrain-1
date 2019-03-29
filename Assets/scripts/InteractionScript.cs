using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class InteractionScript : MonoBehaviour {

    PlayerControl playerControl;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Animator anim1;

    [SerializeField]
    private bool open;

    private void Start()
    {
        playerControl = GetComponent<PlayerControl>();
        open = false;
    }

    // Update is called once per frame
    void Update ()
    {
        anim.SetBool("Open", open);
        if (Input.GetKeyDown(KeyCode.E) || playerControl.state.Buttons.X == ButtonState.Pressed)
        {
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(mouseRay, out hitInfo))
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.blue, 5.0f);
                if (hitInfo.collider.gameObject.tag == "Door")
                {
                    if (open != true)
                    {
                        open = true;
                    } else
                    {
                        open = false;
                    }
                }
                //DoorOpenScript door = hitInfo.transform.GetComponent<DoorOpenScript>();
                //if (door != door.enabled)
                //{
                   // door.enabled = true;
               //}
               //else
               //{
                   // door.enabled = false;
               //}
            }
        }
	}
}
