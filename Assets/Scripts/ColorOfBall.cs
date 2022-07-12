using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOfBall : MonoBehaviour
{
    Rigidbody rb;
    public float bounceForce = 400f;
    public GameObject splitPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(rb.velocity.x, bounceForce * Time.deltaTime, rb.velocity.z);
        GameObject newSplit = Instantiate(splitPrefab, new Vector3(transform.position.x, collision.transform.position.y+ 0.741f, transform.position.z), transform.rotation);
        newSplit.transform.localScale = Vector3.one * Random.Range(1.4f, 2f);
        newSplit.transform.parent = collision.transform;
    }
}
