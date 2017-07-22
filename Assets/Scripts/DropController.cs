using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour {

    public GameObject dropPrefab;
    private List<GameObject> drops;
    private float timeToDrop;
    private float timeBetweenDrops = 0.01f;
    private float xzRange = 20.0f;
    private const float yRange = 1.0f;

    void CreateDrop() {
        Vector3 pos = transform.position;
        pos.x += Random.Range(-1 * xzRange, xzRange);
        pos.y += Random.Range(-1 * yRange, yRange);
        pos.z += Random.Range(-1 * xzRange, xzRange);
        drops.Add((GameObject)Instantiate(dropPrefab, pos, transform.rotation));
    }

    // Use this for initialization
    void Start () {
        drops = new List<GameObject>();
        timeToDrop = timeBetweenDrops;
    }

    // Update is called once per frame
    void Update () {
        timeToDrop += Time.deltaTime;
        if (timeToDrop > timeBetweenDrops) {
            CreateDrop();
            timeToDrop = 0.0f;
        }

        // Iterate through drops and find those to remove.
        List<int> toRemove = new List<int>();
        for (var i = 0; i < drops.Count; i++) {
            Rigidbody drop = drops[i].GetComponent<Rigidbody>();
            // Remove drops that might be outside ground area.
            if (drop.position.y < -100.0f) {
                toRemove.Add(i);
            }
            // Remove drops that have landed.
            else if (drop.velocity.magnitude < 1.0f) {
                if (drop.position.y < transform.position.y - yRange) {
                    toRemove.Add(i);
                }
            }
        }

        // Remove the flagged drops.
        foreach (var i in toRemove) {
            GameObject drop = drops[i];
            drops.RemoveAt(i);
            Destroy(drop);
        }
    }
}
