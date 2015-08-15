using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public Character Character;
	public const int MoveAccel = 50;
	public const float MAXSPEED = 25.0f;

	void Awake() 
    {
		Character = GetComponent<Character> ();
	    Character.Init(MoveAccel);
	}
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () {
		//Move Up
		if (Input.GetKey (KeyCode.W)) 
        {

		}
		//Move Down
		else if (Input.GetKey (KeyCode.S)) 
        {

		}
		//Move Right
		if (Input.GetKey (KeyCode.D)) 
        {
		    Character.MoveRight();
        }
		//Move Left
		else if (Input.GetKey (KeyCode.A)) 
        {
			Character.MoveLeft();
		}
	}
}
