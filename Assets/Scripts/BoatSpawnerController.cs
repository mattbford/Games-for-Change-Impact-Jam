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
                    boat = Instantiate(medBoat, transform);
                    break;
                case BoatType.large:
                    boat = Instantiate(largeBoat, transform);
                    break;
			}
            BoatHandler boatController = boat.GetComponent<BoatHandler>();
            boatController.accelerationFactor = accelerationFactor;
		}
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
	}
}
