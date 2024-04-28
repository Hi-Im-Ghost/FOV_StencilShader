using UnityEngine;

public struct EdgeInfo
{
    public Vector2 pointA;
    public Vector2 pointB;

    public EdgeInfo(Vector2 _pointA, Vector2 _pointB)
    {
        pointA = _pointA;
        pointB = _pointB;
    }
}
