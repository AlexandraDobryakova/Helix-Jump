using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastCircle : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
