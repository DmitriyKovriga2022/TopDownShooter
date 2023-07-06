using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovePath : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float speed = 0;
    [SerializeField] private int currentPoint = 0;

    private float minDistanceToStep = 0.1f;
    private float distance;
    private NavMeshPath path;

    public void Initialise(NavMeshPath path)
    {
        this.path = path;
        rigidbody = GetComponent<Rigidbody2D>();
        speed = 60;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void FixedUpdate()
    {
        if (path.corners.Length == 0) return;

        if (path.status != NavMeshPathStatus.PathComplete) return;

        if (currentPoint + 1 >= path.corners.Length)
        {
            currentPoint = 0;
        }

        distance = Vector3.Distance(transform.position, path.corners[currentPoint]);
        if (distance > minDistanceToStep)
        {
            var direction = (path.corners[currentPoint] - transform.position);
            if (direction.magnitude > 1)
            {
                direction = direction.normalized;
            }

            rigidbody.velocity = direction * speed * Time.fixedDeltaTime;
            //Debug.DrawLine(transform.position, path.corners[currentPoint]);
        }
        else
        {
            if (currentPoint + 1 >= path.corners.Length)
            {
                path.ClearCorners();
                currentPoint = 0;
            }
            else
            {
                //currentPoint = (currentPoint + 1) % pathPoints.Length;
                currentPoint++;
                path.corners[currentPoint].z = 0;
            }
        }
    }
}
