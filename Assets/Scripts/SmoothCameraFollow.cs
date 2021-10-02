using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;

    public Transform camTransform;
    public Vector3 offset;

    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        offset = camTransform.position - target.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 targetPos = target.position + offset;
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
