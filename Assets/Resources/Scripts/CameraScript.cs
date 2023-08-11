using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public int currentId;
    public List<Transform> targets = new List<Transform>();
    public float smoothing = 5f;

    void Start()
    {
        SetNewTarget(0);
    }

    public void SetNewTarget(int id)
    {
        currentId = id;
    }

    void FixedUpdate()
    {
        Vector3 targetCamRot = targets[currentId].eulerAngles;
        transform.position = Vector3.Lerp(transform.position, targets[currentId].position, smoothing * Time.deltaTime);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetCamRot, smoothing * Time.deltaTime);
    }
}
