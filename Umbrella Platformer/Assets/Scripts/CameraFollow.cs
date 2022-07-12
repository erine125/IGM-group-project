using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;

    public float smoothSpeed = 0.75f;

    public Vector3 offset;

    public Vector3 minVals, maxVals;

    void Start() {

    }

    void Update() {

        Vector3 desiredPosition = target.position + offset;

        // before lerp, check if target is outside of bounds
        Vector3 boundPosition = new Vector3(Mathf.Clamp(desiredPosition.x, minVals.x, maxVals.x), Mathf.Clamp(desiredPosition.y, minVals.y, maxVals.y),
                Mathf.Clamp(desiredPosition.z, minVals.z, maxVals.z));

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, boundPosition, smoothSpeed*Time.fixedDeltaTime);

        transform.position = smoothedPosition;

    }
}
