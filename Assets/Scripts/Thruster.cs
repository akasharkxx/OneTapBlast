using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float angle, speed;

    private float elapsedTime, currentAngle;

    private void Start()
    {
        currentAngle = angle;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime > Random.Range(2, 3))
        {
            currentAngle = -currentAngle;
            elapsedTime = 0;
        }

        transform.Rotate(new Vector3(0f, 0f, transform.position.z + currentAngle));
    }
}
