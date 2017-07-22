using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpSpeed;
    public float moveSpeed;
    public float maxSpeed;
    public float gravity;
    public float moveDamp;
    private CharacterController cc;
    private Vector3 moveDirection;

    private void HandleMoveDamp() {
        float damp = (1.0f - moveDamp);
        if (damp > 1.0f) { damp = 1.0f; }
        if (damp < 0.0f) { damp = 0.0f; }
        moveDirection.x *= damp;
        moveDirection.z *= damp;
    }

    // Use this for initialization
    void Start () {
        jumpSpeed = 7.0f;
        moveSpeed = 0.75f;
        maxSpeed = 5.0f;
        gravity = 2.0f;
        moveDamp = 0.15f;
        cc = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update () {
        if (cc.isGrounded) {
            moveDirection.y = 0.0f;
            HandleMoveDamp();
            if (Input.GetKey("w")) { moveDirection += Vector3.forward * moveSpeed; }
            if (Input.GetKey("s")) { moveDirection += Vector3.back * moveSpeed; }
            if (Input.GetKey("d")) { moveDirection += Vector3.right * moveSpeed; }
            if (Input.GetKey("a")) { moveDirection += Vector3.left * moveSpeed; }
            if (Input.GetKey("space")) {
                moveDirection.y = jumpSpeed;
            }
        } else{
            moveDirection += (Physics.gravity * gravity) * Time.deltaTime;
        }
        moveDirection = Vector3.ClampMagnitude(moveDirection, maxSpeed);
        cc.Move(moveDirection * Time.deltaTime);
    }

    public float Speed() {
        return cc.velocity.magnitude;
    }
}
