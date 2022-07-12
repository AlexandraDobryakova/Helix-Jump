using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeCircle : MonoBehaviour // ring
{
    private Transform Player;
    public GameObject part;

    float radius = 100f;
    float force = 500f;

    public static int countOfBrakeParts = 0;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (transform.position.y > Player.position.y)
        {
            FindObjectOfType<AudioManager>().Play("Whoosh");
            part.GetComponent<Rigidbody>().isKinematic = false;
            part.GetComponent<Rigidbody>().useGravity = true;
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider newCollider in colliders)

            {
                Rigidbody rb = newCollider.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddExplosionForce(force, transform.position, radius);
            }
            part.GetComponent<MeshCollider>().enabled = false;
            part.transform.parent = null;
            Destroy(part.gameObject, 2f);
            countOfBrakeParts++;
            GameManager.score = countOfBrakeParts / 10;
            Destroy(this.gameObject, 5f);
            enabled = false;
            GameManager.countOfPassedCircles++;
        }
    }
}

