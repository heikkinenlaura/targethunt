using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    float zMovement, rotation;
    float moveSpeed;
    float rotateSpeed;
    void Start()
    {
        moveSpeed = 10f;
        rotateSpeed = 50f;
    }




    void FixedUpdate()
    {
        zMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;



        Vector3 lookHere = new Vector3(0, rotation * rotateSpeed * 50 * Time.deltaTime, 0);



        transform.Translate(zMovement, 0, 0);
        transform.Rotate(lookHere);
    }
}