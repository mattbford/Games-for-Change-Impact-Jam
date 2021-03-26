using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHandler : MonoBehaviour
{
    public float accelerationFactor = 15f;
    public int maxHp = 5;
    public GUIController gui;
    public bool NPC;
    
    private Rigidbody rb;
    private int currHp;
    private bool isBouncing = false;
    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currHp = 3;
        if(!NPC)
            gui.SetHP(currHp, maxHp);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (!isBouncing)
        {
            Vector3 translation = transform.forward;
			if (!NPC)
			{
                float vertical = Input.GetAxisRaw("Vertical");
                float horizontal = Input.GetAxisRaw("Horizontal");

                translation *= accelerationFactor * vertical;
                translation += transform.right * accelerationFactor * horizontal;
            } else
			{
                translation *= accelerationFactor;
			}

            rb.AddForce(translation, ForceMode.Acceleration);
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
                rb.AddForce(collision.contacts[0].normal * 6f, ForceMode.Impulse);
                isBouncing = true;
                Invoke("StopBounce", 0.3f);
                break;
            case "boat":
                UpdateHP(-1);
                rb.AddForce(collision.contacts[0].normal * 15f, ForceMode.Impulse);
                isBouncing = true;
                Invoke("StopBounce", 0.3f);
                break;
            case "player":
                rb.AddForce(collision.contacts[0].normal * 15f, ForceMode.Impulse);
                isBouncing = true;
                Invoke("StopBounce", 0.3f);
                break;
        }

        if(currHp <= 0)
		{
            GameOver();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
        GameObject obj = other.gameObject;
        switch(obj.tag)
		{
            case "collectable":
                Destroy(obj);
                UpdateHP(1);
                break;
		}
	}

	public void UpdateHP (int amount)
	{
        if(!NPC && currHp < maxHp)
		{
            currHp += amount;
            gui.SetHP(currHp, maxHp);
        }
	}

    private void StopBounce()
	{
        isBouncing = false;
	}

    private void GameOver()
	{

	}
}
