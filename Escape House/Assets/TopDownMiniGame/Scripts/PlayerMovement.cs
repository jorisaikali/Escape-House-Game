using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6f;

    private Vector3 movement;
    private Rigidbody playerRigidbody;

	// Use this for initialization
	void Awake () {
        playerRigidbody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Rotate();
    }

    private void Move(float h, float v)
    {
        //movement.Set(h, 0f, v);
        //movement = movement.normalized * speed * Time.deltaTime;

        //playerRigidbody.MovePosition(transform.position + movement);

        if (Input.GetKey(KeyCode.W))
        {
            movement = Camera.main.transform.GetChild(0).transform.forward;
            transform.position += movement.normalized * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement = Camera.main.transform.GetChild(0).transform.forward;
            transform.position -= movement.normalized * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement = Camera.main.transform.GetChild(0).transform.right;
            transform.position -= movement.normalized * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement = Camera.main.transform.GetChild(0).transform.right;
            transform.position += movement.normalized * Time.deltaTime * speed;
        }

        
    }

    private void Rotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(ray, out floorHit, 100f, LayerMask.GetMask("Floor")))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }
}
