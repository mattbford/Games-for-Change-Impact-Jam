using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHandler : MonoBehaviour
{
    public float accelerationFactor = 15f;
    public float rotateSpeed = 1;
    public int maxHp = 5;
    public GUIController gui;
    
    private Rigidbody rb;
    private int currHp;
    private bool isBouncing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currHp = 3;
        gui.SetHP(currHp, maxHp);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (!isBouncing)
        {
            float vertical = Input.GetAxisRaw("Vertical");

            float horizontal = Input.GetAxisRaw("Horizontal");
            Quaternion rotation = transform.rotation * Quaternion.Euler(0, horizontal * rotateSpeed, 0);

            rb.AddForce(transform.forward * accelerationFactor * vertical, ForceMode.Acceleration);
            rb.MoveRotation(rotation);
        }
    }

	private void OnCollisionEnter(Collision collision)
	{
        GameObject obj = collision.gameObject;
		switch(obj.tag)
        {
            case "damage":
                UpdateHP(-1);
                Destroy(obj);
                rb.AddForce(collision.contacts[0].normal * 5f, ForceMode.Impulse);
                isBouncing = true;
                Invoke("StopBounce", 0.3f);
                break;
        }
	}

	private void OnTriggerEnter(Collider other)
	{
        GameObject obj = other.gameObject;
        switch(obj.tag)
		{
            case "collectable":
                UpdateHP(1);
                Destroy(obj);
                break;
		}
	}

	public void UpdateHP (int amount)
	{
        currHp += amount;
        gui.SetHP(currHp, maxHp);
	}

    private void StopBounce()
	{
        isBouncing = false;
	}
}
