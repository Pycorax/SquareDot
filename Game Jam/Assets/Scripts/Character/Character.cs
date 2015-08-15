using System;
using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
    // Public Fields
    public Skill attackSkill = new Skill();
	public Rigidbody2D CharacterRigidBody;
	public float JumpSpeed = 2.5f;
	public float MaxSpeed = 10f;
    public float MoveAccel = 2.5f;
	public float Gravity = 9.8f;
	public float FrictionCoefficent = 2.0f;
	public const float MaxHealth = 100.0f;
	private float health = MaxHealth;

	void Awake()
	{
		CharacterAwake ();
	}

	protected void CharacterAwake()
	{
		CharacterRigidBody = GetComponent<Rigidbody2D> ();
		CharacterRigidBody.position = transform.position;
		CharacterRigidBody.mass = 1;
	}

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
		CharacterUpdate ();
	}

	// Update is called once per frame
	protected void CharacterUpdate () 
	{
		//Calculate the friction force
		float frictionForce = CharacterRigidBody.mass * Gravity * FrictionCoefficent;
		Vector2 normalizedVelocity = CharacterRigidBody.velocity.normalized;
		float frictionIn_X_Axis = -normalizedVelocity.x * frictionForce;
		
		//Update character velocity based on opposite forces
		CharacterRigidBody.velocity += new Vector2 (frictionIn_X_Axis, -Gravity) * Time.deltaTime;
		
		//Change x to 0 when x is close to 0
		if (CharacterRigidBody.velocity.x < 0.5f && CharacterRigidBody.velocity.x > -0.5f) {
			CharacterRigidBody.velocity = new Vector2 ( 0, CharacterRigidBody.velocity.y);
		}
	}

    // Initialization
    public void Init(float movementAcceleration)
    {
        MoveAccel = movementAcceleration;
    }

    // Movement
    public void MoveLeft()
    {
        CharacterRigidBody.velocity += (new Vector2(-MoveAccel, 0) * Time.deltaTime);
		if (CharacterRigidBody.velocity.x < - MaxSpeed) {
			CharacterRigidBody.velocity = new Vector2(-MaxSpeed, CharacterRigidBody.velocity.y);
		}
    }

    public void MoveRight()
    {
        CharacterRigidBody.velocity += (new Vector2(MoveAccel, 0) * Time.deltaTime);
		if(CharacterRigidBody.velocity.x > MaxSpeed) {
			CharacterRigidBody.velocity = new Vector2(MaxSpeed, CharacterRigidBody.velocity.y);
		}
    }
	public void Jump()
	{
		CharacterRigidBody.velocity += (new Vector2 (0, JumpSpeed));
	}

	// Actions
	public virtual void Attack()
	{
		
	}
	
	public virtual int GetBasicDamage()
	{
		throw new NotImplementedException();
		
		return 0;
	}
}