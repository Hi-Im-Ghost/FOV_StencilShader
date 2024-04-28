using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    [SerializeField] private LayerMask objectsMask;
    [SerializeField] private LayerMask wallsMask;
    public float viewRadius = 20f;
    [Range(0f, 360)]
    public float viewAngle = 60f;
    public List<Transform> visibleObjects = new List<Transform>();

    private void Start()
    {
        StartCoroutine(FindObjectsWithDelay(0.2f));
    }

    IEnumerator FindObjectsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleObjects();
        }
    }

    private void FindVisibleObjects()
    {
        visibleObjects.Clear();
        Collider2D[] objectsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, objectsMask);
        for(int i= 0; i < objectsInViewRadius.Length; i++)
        {
            Transform target = objectsInViewRadius[i].transform;
            Vector2 dirToObject = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
            if (Vector2.Angle (dirToObject, transform.right) < viewAngle / 2)
            {
                float distanceToObject = Vector2.Distance (transform.position, target.position);

                if(!Physics2D.Raycast(transform.position, dirToObject, distanceToObject, wallsMask))
                {
                    visibleObjects.Add(target);
                }
            }
        }
    }

    public Vector2 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if(!angleIsGlobal)
        {
            angleInDegrees += GetComponent<Rigidbody2D>().rotation;
        }
        return new Vector2(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad));
        
    }

    public ViewCastInfo ViewCast(float globalAngle)
    {
        Vector2 dir = DirFromAngle(globalAngle, false);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, viewRadius, wallsMask);
        
        if (hit.collider != null)
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, (Vector2)transform.position + dir * viewRadius, viewRadius, globalAngle);
        }
    }



}
