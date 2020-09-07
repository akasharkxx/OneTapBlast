using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform thruster;
    [SerializeField] private float force;
    [SerializeField] private bool isImpulse;

    private bool isTouching;
    private Rigidbody2D playerBody;
    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //isTouching = true;
            playerBody.AddRelativeForce(-thruster.right * force, isImpulse ? ForceMode2D.Impulse : ForceMode2D.Force);
        }
        //else
        //{
        //    isTouching = false;
        //}
    }

    //private void FixedUpdate()
    //{
    //    if (isTouching)
    //    {
    //        playerBody.AddRelativeForce(-thruster.right * force, isImpulse ? ForceMode2D.Impulse : ForceMode2D.Force);
    //    }
    //}

}
