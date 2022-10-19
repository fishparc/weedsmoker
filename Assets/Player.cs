using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController cc;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        cc =GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("horizontal");
        float v = Input.GetAxis("vertical");
        Vector3 dir = new Vector3(h,0,v);
        
    if (dir.magnitude > 0.1f)
        {
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
     Vector3 move=dir*speed;
     if (!cc.isGrounded)
        {
            move.y = -9.8f * 100 * Time.deltaTime;
        }
cc.Move(dir*Time.deltaTime*speed);
    }
}
