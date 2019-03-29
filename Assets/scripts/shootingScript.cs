using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class shootingScript : MonoBehaviour
{
    [SerializeField] GameObject bloodHit;
    AudioSource audioSrc;
    [SerializeField] AudioClip shootclip;
    PlayerControl playerControl;

    [SerializeField]
    int damageDealt = 20;

    [SerializeField]
    LayerMask layermask;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerControl = GetComponent<PlayerControl>();
        //layermask |= Physics.IgnoreRaycastLayer;
        layermask = ~layermask;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetButtonDown("Fire1") || playerControl.state.Triggers.Right == 1)
        {
            //Make a raycast with the line starting from center of camera
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            anim.SetTrigger("Fire");
            audioSrc.clip = shootclip;
            audioSrc.Play();
            GetComponentInChildren<ParticleSystem>().Play();

            //Send the raycast and if the raycast hit something, print out the name to console
            if (Physics.Raycast(mouseRay, out hitInfo,100, ~layermask)) {
                print(hitInfo.transform);
                EnemyHealth enemyHealth = hitInfo.transform.GetComponent<EnemyHealth>(); 
                Debug.DrawLine(transform.position, hitInfo.point, Color.red, 5.0f);

                if (enemyHealth != null)
                {
                    enemyHealth.Damage(damageDealt);
                    Vector3 bloodHitPos = hitInfo.point;
                    Quaternion bloodHitRot = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);
                    Instantiate(bloodHit, bloodHitPos, bloodHitRot);
                }
            }
        }
    }
}
