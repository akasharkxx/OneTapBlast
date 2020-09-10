using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothness;
    [SerializeField] private Transform player;

    private Camera mainCamera;
    private Vector2 refVelocity;

    private void Start()
    {
        mainCamera = Camera.main;
        refVelocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.SmoothDamp(transform.position, player.position, ref refVelocity, smoothness);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }

}
