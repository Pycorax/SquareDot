using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public Character Character;
	public const int FORCE = 50;
	public const float MAXSPEED = 25.0f;
	public static bool IsSpacePressed = false;

	void Awake() {
		Character = GetComponent<Character> ();

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Move Up
		if (Input.GetKey (KeyCode.W)) {

		}
		//Move Down
		else if (Input.GetKey (KeyCode.S)) {

		}

		//Move Right
		if (Input.GetKey (KeyCode.D)) {
			Character.CharacterRigidBody.velocity += (new Vector2(FORCE, 0) * Time.deltaTime);

			/*if(Character.CharacterRigidBody.velocity.x > MAXSPEED)
			{
				Character.CharacterRigidBody.velocity = new Vector2(MAXSPEED, Character.CharacterRigidBody.velocity.y);
			}*/
		}
		//Move Left
		else if (Input.GetKey (KeyCode.A)) {
			Character.CharacterRigidBody.velocity += (new Vector2(-FORCE, 0) * Time.deltaTime);
			/*if(Character.CharacterRigidBody.velocity.x < -MAXSPEED)
			{
				Character.CharacterRigidBody.velocity = new Vector2(-MAXSPEED, Character.CharacterRigidBody.velocity.y);
			}*/
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
