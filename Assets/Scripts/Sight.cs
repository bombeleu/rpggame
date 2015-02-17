using UnityEngine;
using System.Collections;
using System;

public class Sight:MonoBehaviour
{
    [SerializeField]
    private float m_headHeight;
    [SerializeField]
    private float m_distance;

    // Use this for initialization
    void Start ()
    {
        Debug.Log ( "Start" );
    }

    // Update is called once per frame
    void Update ()
    {
        RaycastHit hit;
        var playerPos = GetComponent<Transform> ().position;
        playerPos.y += m_headHeight;
        Ray frontRay = new Ray ( playerPos, Vector3.forward );
        Debug.DrawRay ( playerPos, Vector3.forward * m_distance );
        if (Physics.Raycast ( frontRay, out hit, m_distance ))
        {
            Debug.Log ( String.Format ( "distance: {0}, z: {1}, y: {2}", hit.distance, frontRay.origin.z, frontRay.origin.y ) );
        }
    }
}
