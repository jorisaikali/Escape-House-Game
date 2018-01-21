using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

    // ---------- Public variables ---------- //
    public float moveSpeed = 5f;
    public float mouseSensitivity = 5f;
    public float verticalRange = 60f;
    // -------------------------------------- //

    // ---------- Private variables ---------- //
    private float verticalRotation = 0f;
    private GameObject gameObjectHit = null;
    private float camRayLength = 100f;
    private InputManager inputManager;
    private bool lockMovement = false, lockRotation = false;
    // --------------------------------------- //

    private void Start ()
    {
        // --------- Configuring the cursor --------- //
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // ------------------------------------------ //

        // --------- Getting references to other scripts --------- //
        inputManager = GetComponent<InputManager>();
        // ------------------------------------------------------- //
    }

	private void Update ()
    {
        if (!lockMovement) // Check if movement is locked, if not locked, allow movement
            Move();

        if (!lockRotation) // Check if rotatio is locked, if not locked, allow rotating
            Look();
	}

    // ------------------------ Moving the player ------------------------ //
    private void Move()
    {
        float forwardSpeed = inputManager.getPlayerAxis("Vertical") * moveSpeed;
        float sideSpeed = inputManager.getPlayerAxis("Horizontal") * moveSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0f, forwardSpeed);
        speed = transform.rotation * speed;

        CharacterController cc = GetComponent<CharacterController>();
        cc.SimpleMove(speed);
    } 
    // ------------------------------------------------------------------- //

    // ------------------------ Controls the players rotation ------------------------ //
    private void Look()
    {
        float rotLeftRight = inputManager.getPlayerAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, rotLeftRight, 0f);

        verticalRotation -= inputManager.getPlayerAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRange, verticalRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
    // -------------------------------------------------------------------------------- //

    // -------------------------- Getting what the player is looking at -------------------------- //
    /* Checks what the player is looking at on the mask layer. Returns the game object being looked at,
       null if looking at nothing on that mask */
    public GameObject GetRayCast(LayerMask mask)
    {
        Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, camRayLength, mask))
        {
            gameObjectHit = hit.transform.gameObject;
        }
        else
        {
            gameObjectHit = null;
        }

        return gameObjectHit;
    }
    // -------------------------------------------------------------------------------------------- //

    // ---------- Locking/Unlocking player movement/rotate ---------- //
    public void LockMovement() { lockMovement = true; }
    public void LockRotation() { lockRotation = true; }
    public void UnlockMovement() { lockMovement = false; }
    public void UnlockRotation() { lockRotation = false; }
    // -------------------------------------------------------------- //
}
