using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float speed = 5f;
    private bool slow = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            slow = !slow;
            Time.timeScale = slow ? 0.1f : 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        // Input Axis
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Normalize movement to avoid faster diagonal movement
        Vector3 movement = new Vector3(h, 0, v).normalized * speed * Time.unscaledDeltaTime;

        // Translate the player
        transform.Translate(movement, Space.World);
    }

}
