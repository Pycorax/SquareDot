﻿using System;
using UnityEngine;
using System.Collections;

public interface ICharacterTag
{
    string Tag { get; }
}

public abstract class Character : MonoBehaviour
{
    // Public Fields
    public Skill AttackSkill;
	public const float MaxHealth = 100f;
	public float JumpSpeed = 2.5f;
	public float MaxSpeed = 10f;
    public float MoveAccel = 2.5f;
	public float Gravity = 9.8f;
	public float FrictionCoefficent = 2.0f;

    // Private Variables
    protected Rigidbody2D CharacterRigidBody;
	private float Health = MaxHealth;

	void Awake ()
	{
		CharacterAwake ();
	}

	protected void CharacterAwake () 
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
        AttackSkill.UpdateCooldown();
    }

	protected void CharacterUpdate()
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
    public abstract void Attack();

	public virtual void TakeDamage(float damage)
	{
		Health -= damage;
		if (Health <= 0) {
			// Character dies set active to false
		}
	}

    public virtual int GetBasicDamage()
    {
        throw new NotImplementedException();

        return 0;
    }
}
