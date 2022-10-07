using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamControl : MonoBehaviour
{
    public Transform currentMount;
    public Camera cam;
    public float speed;
    public float zoom;
    private Vector3 lastposition;

    private void Start()
    {
        lastposition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentMount.position, speed);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speed);

        float velocity = Vector3.Magnitude(transform.position - lastposition);
        cam.fieldOfView = 60 + velocity * zoom;
        lastposition = transform.position;
    }
    
    public void SetMount(Transform newMount)
    {
        currentMount = newMount;
    }
}
