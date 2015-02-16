using UnityEngine;
using System.Collections;

public class GetInput : MonoBehaviour 
{
	private bool isSprint;
	private bool isPause;
    public float turnSmoothing = 15f;	// A smoothing value for turning the player.
    public float speedDampTime = 0.1f;
	[SerializeField]
	private GameObject m_skillPanel;
	private float x;

	private Animator anim;

	void Awake ()
	{ 
		isPause = false;
		anim = GetComponent <Animator> ();
		m_skillPanel.SetActive ( false );
	}

	public void SprintFunction ( bool _isSprint)
	{
		isSprint = _isSprint;
	}

	void FixedUpdate ()
	{
		if (!isPause)
		{
			float vertical = Input.GetAxis ("Vertical");
			float horizontal = Input.GetAxis ("Horizontal");
			isSprint = Input.GetButton ("Sprint");
			MovementManager (vertical, horizontal, isSprint);
		}
	}

	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.G))
            GetComponent <Attributes> ().IncreaseExp ( 101 );

        if ( Input.GetKeyUp ( KeyCode.E ) )
        {
            Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );
            RaycastHit hit;
            if ( collider.Raycast ( ray, out hit, 100.0F ) )
                Debug.DrawLine ( ray.origin, hit.point );
        }

		bool isShowSkillPanel = Input.GetKeyUp ( KeyCode.J );
		if (m_skillPanel.activeInHierarchy && isShowSkillPanel)
		{
			isPause = false;
            m_skillPanel.SetActive (isPause);
		}
		else if (!m_skillPanel.activeInHierarchy && isShowSkillPanel)
		{
			isPause = true;
			m_skillPanel.SetActive (isPause);
		}
	}

    void MovementManager(float vertical, float horizontal, bool isSprint)
    { 
        if ( vertical != 0.0f )
        {
            GetComponent<Rigidbody> ().freezeRotation = false;
            x += Input.GetAxis ( "Mouse X" ) * 25f * 0.02f;
            var rotation = Quaternion.Euler ( 0, x, 0 );
            rigidbody.rotation = rotation;
            GetComponent<Rigidbody> ().freezeRotation = true;
        }
        anim.SetBool ( "Sprint", isSprint );
		anim.SetFloat("NarutoSpeed", vertical, 0.1f, Time.deltaTime);
    }

    void Rotate(float vertical, float horizontal)
    {
        // Create a new vector of the horizontal and vertical inputs.
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

        // Create a rotation based on this new vector assuming that up is the global y axis.
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        // Create a rotation that is an increment closer to the target rotation from the player's rotation.
        Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);

        // Change the players rotation to this new rotation.
        rigidbody.MoveRotation(newRotation);
    }
}
