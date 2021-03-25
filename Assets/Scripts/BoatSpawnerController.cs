using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawnerController : MonoBehaviour
{
    public enum BoatType
	{
        small,
        medium,
        large
	}

    [Header("GameVars")]
    public BoatType boatClass;
    public float accelerationFactor = 15;
    public float maxSpeed = 10;
    public float spawnRadius = 15f;

    [Header("Prefabs")]
    public GameObject smallBoat;
    public GameObject medBoat;
    public GameObject largeBoat;

    private GameObject boat;
    private Rigidbody rb;
    private bool isBouncing;
    private Transform pc;

	private void Start()
	{
        pc = GameObject.FindWithTag("Player").transform;
    }

	// Update is called once per frame
	void FixedUpdate()
    {
        if(boat == null && Vector3.Distance(transform.position, pc.position) <= spawnRadius)
		{
			switch (boatClass)
			{
                case BoatType.small:
                    boat = Instantiate(smallBoat, transform);
                    break;
                case BoatType.medium:
                    break;
                case BoatType.large:
                    break;
			}
		}
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
	}
}
