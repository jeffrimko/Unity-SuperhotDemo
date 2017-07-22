using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public float sceneSpeed;
    private PlayerController player;
    private const float MAX_SPEED_SCALE = 8.0f;
    private const float MIN_SCENE_SPEED = 0.1f;
    private const float UNITY_DEFAULT_STEP = 0.02f;

    // Use this for initialization
    void Start () {
        player = (PlayerController)GameObject.Find("Player").GetComponent(typeof(PlayerController));
        sceneSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update () {
        sceneSpeed = (player.Speed() / MAX_SPEED_SCALE) + MIN_SCENE_SPEED;
        Time.timeScale = sceneSpeed;
        Time.maximumDeltaTime = sceneSpeed;
        Time.fixedDeltaTime = sceneSpeed * UNITY_DEFAULT_STEP;
    }
}
