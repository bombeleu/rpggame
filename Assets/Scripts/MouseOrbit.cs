using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour 
{
    public Transform target;
    public float distance = 10.0f;

    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20;
    public float yMaxLimit = 80;

    private float x;
    private float y;

    // Use this for initialization
    void Start ()
    {
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
	        GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void LateUpdate ()
    {
        if ( target )
        {
            if ( Input.GetAxis ( "Vertical" ) > 0f )
            {
                //x += Input.GetAxis("Mouse X") * 115f * 0.02;
                transform.rotation = target.rotation;
                transform.position = transform.rotation * new Vector3 ( 0.0f, 5.0f, -distance ) + target.position;
                x = transform.eulerAngles.y;
                y = transform.eulerAngles.x;
            }
            else
            {
                x += Input.GetAxis ( "Mouse X" ) * xSpeed * 0.02f;
                y -= Input.GetAxis ( "Mouse Y" ) * ySpeed * 0.02f;

                y = ClampAngle ( y, yMinLimit, yMaxLimit );

                var rotation = Quaternion.Euler ( y, x, 0 );
                var position = rotation * new Vector3 ( 0.0f, 2.0f, -distance ) + target.position;

                transform.rotation = rotation;
                transform.position = position;
            }
        }
    }

    static float ClampAngle ( float angle, float min, float max )
    {
        if ( angle < -360 )
            angle += 360;
        if ( angle > 360 )
            angle -= 360;
        return Mathf.Clamp ( angle, min, max );
    }
}
