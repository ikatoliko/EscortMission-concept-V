using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coordsystem : MonoBehaviour
{
    // Start is called before the first frame update
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(Vector3.zero, Vector3.right * 100);
        Gizmos.DrawLine(Vector3.zero, Vector3.left * 100);
        Gizmos.DrawLine(Vector3.zero, Vector3.up * 100);
        Gizmos.DrawLine(Vector3.zero, Vector3.down * 100);
        Gizmos.DrawLine(Vector3.zero, Vector3.forward * 100);
        Gizmos.DrawLine(Vector3.zero, Vector3.back * 100);
        DrawPlane();
    }

    void DrawPlane() {
        var position = Vector3.zero;
        var toNormalize = new Vector3(1,1,1);
        Vector3 v;
        if(toNormalize.normalized != Vector3.forward) {
            v = Vector3.Cross(toNormalize, Vector3.forward).normalized * toNormalize.magnitude;
        } else {
            v = Vector3.Cross(toNormalize, Vector3.up).normalized * toNormalize.magnitude;
        }

        var corner0 = position + v;
        var corner2 = position - v;

        var q = Quaternion.AngleAxis(90f, toNormalize);
        v = q * v;
        var corner1 = position + v;
        var corner3 = position - v;
        Debug.DrawLine(corner0, corner2, Color.green);
        Debug.DrawLine(corner1, corner3, Color.green);
        Debug.DrawLine(corner0, corner1, Color.green);
        Debug.DrawLine(corner1, corner2, Color.green);
        Debug.DrawLine(corner2, corner3, Color.green);
        Debug.DrawLine(corner3, corner0, Color.green);
        Debug.DrawRay(position, toNormalize, Color.red);
    }
}
