using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AxisEnum { X, Y, Z};

public class oscillation : MonoBehaviour
{
    Vector3 initPos;
    [SerializeField][Range(0,100)]private float amplitude;
    [SerializeField][Range(0,50)] private float frequency;
    [SerializeField]private AxisEnum axis;
    private Rigidbody rb;
    private void Start()
    {
        initPos = transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        switch (axis)
        {
            case AxisEnum.X:
                rb.MovePosition(new Vector3(Mathf.Sin(Time.time * frequency) * amplitude + initPos.x, initPos.y, initPos.z));
                break;
            case AxisEnum.Y:
                rb.MovePosition(new Vector3(initPos.x, Mathf.Sin(Time.time * frequency) * amplitude + initPos.y, initPos.z));
                break;
            case AxisEnum.Z:
                rb.MovePosition(new Vector3(initPos.x, initPos.y, Mathf.Sin(Time.time * frequency) * amplitude + initPos.z));
                break;
            default:
                break;
        }
    }
}
