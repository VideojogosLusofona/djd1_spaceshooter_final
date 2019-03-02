using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public bool     useRotation;
    public Vector3  moveVector;
    public float    speed = 400;
    public float    horizontalAmplitude = 0;
    public float    horizontalFrequency = 0;

    float   timer = 0.0f;
    Vector3 startPos;
    float   angle = 0.0f;
    Vector3 hVector;

    void Start()
    {
        if (useRotation) moveVector = transform.up;

        moveVector.Normalize();

        hVector = new Vector3(-moveVector.y, moveVector.x, moveVector.z);

        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        angle += horizontalFrequency * Time.fixedDeltaTime;

        float s = horizontalAmplitude * Mathf.Sin(angle * Mathf.Deg2Rad);

        transform.position = startPos + moveVector * speed * timer + hVector * s;
    }

    void Update()
    {
        
    }
}
