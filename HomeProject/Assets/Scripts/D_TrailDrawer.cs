using UnityEngine;
using System.Collections.Generic;

public class D_TrailDrawer : MonoBehaviour
{
    public Transform target;

    private LineRenderer line;
    private List<Vector3> points = new List<Vector3>();

    public float minDistance = 0.1f;

    void Start()
    {
        line = GetComponent<LineRenderer>();

        line.positionCount = 0;
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
    }

    void Update()
    {
        Vector3 currentPos = target.position;

        if (points.Count == 0 ||
            Vector3.Distance(points[points.Count - 1], currentPos) > minDistance)
        {
            AddPoint(currentPos);
        }
    }

    void AddPoint(Vector3 point)
    {
        points.Add(point);

        line.positionCount = points.Count;
        line.SetPosition(points.Count - 1, point);
    }
}