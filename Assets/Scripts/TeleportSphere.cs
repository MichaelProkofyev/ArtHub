using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class TeleportSphere : VRTK_InteractableObject
{

    Vector3 startPosition;

    public bool returningToStart;
    public bool dragged;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        InteractableObjectUngrabbed += ReturnToStart;
        InteractableObjectGrabbed += MakeGrabbable;
        rb = GetComponent<Rigidbody>();
    }

    void MakeGrabbable (object sender, InteractableObjectEventArgs e)
    {
        dragged = true;
    }


    // Update is called once per frame
    override protected void FixedUpdate()
    {
        Debug.Log(rb.velocity);
        base.FixedUpdate();
        if (returningToStart)
        {
            float distanceToStart = Vector3.Distance(startPosition, transform.position);
            Vector3 force = (startPosition - transform.position).normalized * 100f;
            rb.AddForce(force);

            // rb.AddRelativeForce(direction.normalized * speed, ForceMode.Force);

            if (distanceToStart <= 0.5)
            {
                //
                returningToStart = false;
                print("STOPPING");
                transform.position = startPosition;
               
            }
        }
        else if(!dragged)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void ReturnToStart(object sender, InteractableObjectEventArgs e)
    {
        returningToStart = true;
        dragged = false;
        //transform.position = startPosition;
    }
}
