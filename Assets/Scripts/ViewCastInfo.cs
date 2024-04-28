using UnityEngine;

public struct ViewCastInfo
{
    public bool hit;
    public Vector2 point;
    public float dst;
    public float angle;

    public ViewCastInfo(bool _hit, Vector2 _point, float _dst, float _angle)
    {
        hit = _hit;
        point = _point;
        dst = _dst;
        angle = _angle;
    }


}