using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform thruster;
    [SerializeField] private float force;
    [SerializeField] private bool isImpulse;

    private bool isMoving;
    private Rigidbody2D playerBody;
    private float elapsed;
    private void Start()
    {
        elapsed = 0f;
        playerBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //isTouching = true;
            playerBody.AddRelativeForce(-thruster.right * force, isImpulse ? ForceMode2D.Impulse : ForceMode2D.Force);
        }
        elapsed += Time.deltaTime;
        if(elapsed >= 0.8f)
        {
            playerBody.velocity = Vector2.zero;
            elapsed = 0;
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
