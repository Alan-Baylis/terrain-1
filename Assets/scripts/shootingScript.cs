using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingScript : MonoBehaviour
{
    [SerializeField] GameObject bloodHit;

    [SerializeField]
    int damageDealt = 20;

    [SerializeField]
    LayerMask layermask;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        if (Input.GetButtonDown("Fire1"))
        {
            //Make a raycast with the line starting from center of camera
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            anim.SetTrigger("Fire");
            GetComponentInChildren<ParticleSystem>().Play();

            //Send the raycast and if the raycast hit something, print out the name to console
            if (Physics.Raycast(mouseRay, out hitInfo,100, ~layermask)) {
                print(hitInfo.transform);
                EnemyHealth enemyHealth = hitInfo.transform.GetComponent<EnemyHealth>(); 
                Debug.DrawLine(transform.position, hitInfo.point, Color.red, 5.0f);
                EnemyHealth EnemyHealth = hitInfo.transform.GetComponent<EnemyHealth>();

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
