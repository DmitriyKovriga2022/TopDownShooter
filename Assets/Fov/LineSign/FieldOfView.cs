using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public int segments;
    public float radius;

    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private LayerMask mask;

    private Vector3[] points;
    private List<int> triangles;
    private Mesh mesh;

    private void LateUpdate()
    {
        points = CreatePoints(segments, radius);
        DrawMesh(points);
    }

    private Vector3[] CreatePoints(int segments, float radius)
    {
        Vector3[] points = new Vector3[segments + 1];
        float x = 0;
        float y = 0;
        float angle = 0;
        float leight = 0;

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new Vector3(x, y, 0);
            leight = RayHit(points[i], radius);
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * leight;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * leight;
            angle += (360f / segments);
            
        }

        return points;
    }

    private float RayHit(Vector3 targetPoint, float distanceToHit)
    {
        targetPoint = transform.position + targetPoint;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetPoint - transform.position, distanceToHit, mask);
        if (hit.collider != null)
        {
            distanceToHit = Vector3.Distance(transform.position, hit.point);
        }

        return distanceToHit;
    }

    private void DrawMesh(Vector3[] points)
    {
        mesh = new Mesh();
        triangles = new List<int>();

        for (int i = 0; i < points.Length - 2; i++)
        {
            triangles.Add(0);
            triangles.Add(i + 1);
            triangles.Add(i + 2);
        }

        triangles.Add(0);
        triangles.Add(points.Length - 1);
        triangles.Add(1);

        mesh.vertices = points;
        mesh.triangles = triangles.ToArray();
        meshFilter.mesh = mesh;
    }

}
