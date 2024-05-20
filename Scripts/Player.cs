using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TimeManager timeManager;
    public float speed = 5f;

    void Update()
    {
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        // Unscaled delta time to prevent the character from slowing down
        //Vector3 movement = new Vector3(h, 0, v) * speed * Time.unscaledDeltaTime;
        //transform.Translate(movement, Space.World);

        SlowDown();
    }

    void SlowDown()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            timeManager.DoSlowmotion();
        }
    }
}
