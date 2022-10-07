using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragXZ : MonoBehaviour
{
    float mZCoord;
    public float collisionCheckDistance;
    public bool aboutToCollide;
    public float distanceToCollision;
    Vector3 mOffset;
    [SerializeField] float Sensitivity;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }
        if (Input.GetMouseButton(0) && mOffset.x != 0f)
        {
            Vector3 UpDown = new Vector3(GetMouseAsWorldPoint().x + mOffset.x * Sensitivity, transform.position.y, transform.position.z);
            RaycastHit hit;
            if (rb.SweepTest((UpDown - transform.position).normalized, out hit, Mathf.Abs(mOffset.x) + 0.1f))
            {
                aboutToCollide = true;
                distanceToCollision = hit.distance;
            }
            else
            {
                Debug.Log($"{UpDown}");
                rb.MovePosition(UpDown);
            }
        }
        if (Input.GetMouseButton(1) && mOffset.z != 0f)
        {
            Vector3 LeftRight = new Vector3(transform.position.x, transform.position.y, GetMouseAsWorldPoint().z + mOffset.z * Sensitivity);
            RaycastHit hit;
            if (rb.SweepTest((LeftRight - transform.position).normalized, out hit, Mathf.Abs(mOffset.z) + 0.1f))
            {
                aboutToCollide = true;
                distanceToCollision = hit.distance;
            }
            else
            {
                Debug.Log($"{LeftRight}");
                rb.MovePosition(LeftRight);
            }
        }
    }

    private void FixedUpdate()
    {

    }

    Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}