using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float    acceleration = 10000.0f;
    public float    maxSpeed = 400.0f;
    public float    drag = 0.8f;
    public Vector2  limit = new Vector2(600.0f, 300.0f);

    Rigidbody2D rigidBody;
    Animator    anim;
    Vector3     moveVector;
    Vector3     currentVelocity;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        currentVelocity = currentVelocity * drag;

        currentVelocity = currentVelocity + moveVector * acceleration * Time.fixedDeltaTime;

        currentVelocity = currentVelocity.normalized * Mathf.Min(currentVelocity.magnitude, maxSpeed);

        Vector3 newPos = transform.position + currentVelocity * Time.fixedDeltaTime;
        if (newPos.x > limit.x) newPos.x = limit.x;
        else if (newPos.x < -limit.x) newPos.x = -limit.x;

        if (newPos.y > limit.y) newPos.y = limit.y;
        else if (newPos.y < -limit.y) newPos.y = -limit.y;

        transform.position = newPos;

        if (anim)
        {
            anim.SetFloat("SpeedX", currentVelocity.x);
        }
    }

    private void Update()
    {
        moveVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
    }
}
