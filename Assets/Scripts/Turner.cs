using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turner : MonoBehaviour
{
    public float rotationSpeed = 150f;

    void Update()
    {
        if (!GameManager.gameIsStarted)
        {
            return;
        }

        // for PC
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0, -mouseX * rotationSpeed * Time.deltaTime, 0);
        }

        // for mobile
        /*if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float xDelta = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(0, -xDelta + rotationSpeed + Time.deltaTime, 0);
        }*/
    }
}
