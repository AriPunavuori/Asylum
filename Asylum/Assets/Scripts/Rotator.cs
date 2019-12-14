using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    GameObject world;
    GameObject rotator;

    private void Start() {
        world = GameObject.Find("World");
        rotator = GameObject.Find("Rotator");
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            // Move rotator to current portal, set world inside and rotate
            // ToDo: Transition(s) instead of flip
            rotator.transform.position = this.transform.position;
            world.transform.SetParent(rotator.transform, true);
            rotator.transform.Rotate(0, 180, 0);
            world.transform.SetParent(null);
        }
    }
}
