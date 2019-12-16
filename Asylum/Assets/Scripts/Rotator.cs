using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    GameObject world;
    GameObject rotator;
    bool rotating;
    float rotatingSpeed;
    float targetYAngle;
    Transform originalParent;

    private void Start() {
        world = GameObject.Find("World");
        rotator = GameObject.Find("Rotator");
    }

    private void Update() {
        if(rotating) {
            Rotate();
            if(rotator.transform.eulerAngles.y >= targetYAngle) {
                StopRotating();
            }
        }
    }

    public void RotateWorld() {

        if(!rotating) {
            print("Rotation started");
            rotating = true;
            originalParent = transform.parent;
            rotator.transform.position = transform.position; // Set rotator to this objects position to rotate around
            rotator.transform.rotation = Quaternion.identity;
            rotatingSpeed = 100; // Set this to adjust speed of turn (Is set now to use buttons script to run RotateWorld())
            targetYAngle = rotator.transform.eulerAngles.y + 180; // Same here (180)
            world.transform.SetParent(rotator.transform, true);
            transform.parent = null;
        }
    }

    void Rotate() {
        float newAngleDelta = Mathf.MoveTowardsAngle(rotator.transform.eulerAngles.y, targetYAngle, rotatingSpeed * Time.deltaTime);
        rotator.transform.eulerAngles = new Vector3(0, newAngleDelta, 0);
    }

    void StopRotating() {
        rotator.transform.eulerAngles = new Vector3(0, targetYAngle, 0);
        world.transform.SetParent(null);
        transform.parent = originalParent;
        rotating = false;
    }
}
