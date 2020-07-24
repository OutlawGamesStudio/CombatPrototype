using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    public List<PathNode> ConnectedPaths;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.5f);

        Gizmos.color = Color.red;
        foreach(var item in ConnectedPaths)
        {
            Gizmos.DrawLine(transform.position, item.transform.position);
        }
    }
}
