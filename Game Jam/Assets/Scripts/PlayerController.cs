using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public Player Character;
	public const int MoveAccel = 50;
	public const float MAXSPEED = 25.0f;
	public static bool IsSpacePressed = false;

	void Awake() 
    {
		Character = GetComponent<Player> ();
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

		//Jump
		if (Input.GetKey (KeyCode.Space) && !IsSpacePressed) {
			IsSpacePressed = true;
			Character.Jump();
		}
		if (!Input.GetKey (KeyCode.Space) && IsSpacePressed) {
			IsSpacePressed = false;
		}
	}
}
