using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

	public void StartNewLevel ()
	{
		Application.LoadLevel ( "testLevel" );
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
