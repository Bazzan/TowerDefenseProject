﻿
using UnityEngine;

public class CameraController : MonoBehaviour {
    private bool doMovment = true;

    [SerializeField] private float panSpeed = 30f;
    //[SerializeField] private float panBorderThickness = 10f;
    [SerializeField] private float scrollSpeed = 5f;
    [SerializeField] private float minY = 10f;
    [SerializeField] private float maxY = 80f;


    void Update () {

        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovment = !doMovment;
        }

        if (!doMovment)
        {
            return;
        }

        if (Input.GetKey("w") /*|| Input.mousePosition.y >= Screen.height - panBorderThickness*/) // commenting out mouse input
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") /*|| Input.mousePosition.y <= panBorderThickness*/)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") /*|| Input.mousePosition.x >= Screen.width - panBorderThickness*/)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") /*|| Input.mousePosition.x <= panBorderThickness*/)
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
