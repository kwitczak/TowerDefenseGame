﻿using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
    public float panBorderThickness = 10f;
    public float minY = 10f;
    public float maxY = 80f;

    public bool moveMouse = false;

	// Update is called once per frame
	void Update () {

        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        // Move on 'w' or arrow at the top of the screen
        if (Input.GetKey("w") || (moveMouse && Input.mousePosition.y >= Screen.height - panBorderThickness))
        {
            // Time.deltaTime - time since last frame was drawn
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || (moveMouse && Input.mousePosition.y <= panBorderThickness))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || (moveMouse && Input.mousePosition.x >= Screen.width - panBorderThickness))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || (moveMouse && Input.mousePosition.x <= panBorderThickness)) 
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
