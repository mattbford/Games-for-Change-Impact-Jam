using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHandler : MonoBehaviour
{
    public float accelerationFactor = 15f;
    public float rotateSpeed = 1;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");

        float horizontal = Input.GetAxisRaw("Horizontal");
        Quaternion rotation = transform.rotation * Quaternion.Euler(0, horizontal * rotateSpeed, 0);

        rb.AddForce(transform.forward * accelerationFactor * vertical, ForceMode.Acceleration);
        rb.MoveRotation(rotation);
    }
}
