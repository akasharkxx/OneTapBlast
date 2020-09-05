using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float angle, speed;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, transform.position.z + angle));
    }
}
