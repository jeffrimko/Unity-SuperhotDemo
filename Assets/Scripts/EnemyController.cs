using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float moveSpeed;
    private CharacterController cc;
    private Vector3 moveDirection;
    private GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        cc = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
        moveSpeed = 4.0f;
    }

    // Update is called once per frame
    void Update () {
        moveDirection = (player.transform.position - this.transform.position).normalized;
        cc.Move(moveDirection * Time.deltaTime * moveSpeed);
    }
}
