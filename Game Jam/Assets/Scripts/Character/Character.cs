using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{

	public Rigidbody2D CharacterRigidBody;
	public float jumpSpeed = 2.5f;
	public float maxSpeed = 10f;
    public float moveAccel = 10f;
	public float gravity = 9.8f;
	public float frictionCoefficent = 2.0f;

	void Awake(){
		CharacterRigidBody = GetComponent<Rigidbody2D> ();
		CharacterRigidBody.position = Vector2.zero;
		CharacterRigidBody.mass = 1;
	}

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
		//Calculate the friction force
		float frictionForce = CharacterRigidBody.mass * gravity * frictionCoefficent;
		Vector2 normalizedVelocity = CharacterRigidBody.velocity.normalized;
		float frictionIn_X_Axis = -normalizedVelocity.x * frictionForce;

		//Update character velocity based on opposite forces
		CharacterRigidBody.velocity += new Vector2 (frictionIn_X_Axis, -gravity) * Time.deltaTime;

		//Change x to 0 when x is close to 0
		if (CharacterRigidBody.velocity.x < 0.5f && CharacterRigidBody.velocity.x > -0.5f) {
			CharacterRigidBody.velocity = new Vector2 ( 0, CharacterRigidBody.velocity.y);
		}
	}

    // Initialization
    public void Init(float movementAcceleration)
    {
        moveAccel = movementAcceleration;
    }

    // Movement
    public void MoveLeft()
    {
        CharacterRigidBody.velocity += (new Vector2(-moveAccel, 0) * Time.deltaTime);
		if (CharacterRigidBody.velocity.x < - maxSpeed) {
			CharacterRigidBody.velocity = new Vector2(-maxSpeed, CharacterRigidBody.velocity.y);
		}
    }

    public void MoveRight()
    {
        CharacterRigidBody.velocity += (new Vector2(moveAccel, 0) * Time.deltaTime);
		if(CharacterRigidBody.velocity.x > maxSpeed) {
			CharacterRigidBody.velocity = new Vector2(maxSpeed, CharacterRigidBody.velocity.y);
		}
    }
	public void Jump()
	{
		CharacterRigidBody.velocity += (new Vector2 (0, jumpSpeed));
	}
}
