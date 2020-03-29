using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float sizechangeTime = 0.3f;
    public float posy;
    private Vector3 velocity = Vector3.zero;
    private Camera c;
    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    public bool isTargetUpdate;
    public bool isCameraSizeUpdate;
    private float targetSize;
    private float startTimeTargetSize;


// Start is called before the first frame update
    void Start()
    {
        c = GetComponentInParent<Camera>();
        targetSize = c.orthographicSize;
    }

    public void SetSize(float f)
    {
        isCameraSizeUpdate = true;
        startTimeTargetSize = Time.time;
        targetSize = f;
    }

    public float GetSize()
    {
        return c.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTargetUpdate)
        {
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, posy, -10));
            Vector3 desiredPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            c.transform.position = new Vector3(Mathf.Clamp(desiredPosition.x, minX, maxX), Mathf.Clamp(desiredPosition.y, minY, maxY), -10);
        }

        if (isCameraSizeUpdate && !Mathf.Approximately(c.orthographicSize,targetSize))
        {
            float elapsedTime = Time.time - startTimeTargetSize;
            c.orthographicSize = Mathf.Lerp(c.orthographicSize, targetSize, elapsedTime / sizechangeTime);
        }
    }
}
