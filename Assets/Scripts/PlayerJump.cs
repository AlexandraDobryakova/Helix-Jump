using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour // ball
{
    public Rigidbody playerRB;
    public float bounceForce = 400f;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerRB = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        if (!GameManager.levelCompleted) audioManager.Play("Land");
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")
        {
            //Debug.Log("Safe");
        }
        else if (materialName == "Unsafe (Instance)")
        {
            GameManager.gameOver = true;
            //Debug.Log("Game Over");
            audioManager.Play("GameOver");
        }
        else if (materialName == "LastCircle (Instance)" && !GameManager.levelCompleted)
        {
            GameManager.levelCompleted = true;
            //Debug.Log("Level Completed!");
            audioManager.Play("LevelCompleted");
        }
    }
}
