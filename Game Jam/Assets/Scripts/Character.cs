﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{

	public Rigidbody2D CharacterRigidBody;
    private float moveAccel = 50;

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
		CharacterRigidBody.position += CharacterRigidBody.velocity * Time.deltaTime;
		float dragForceMagnitude = (CharacterRigidBody.velocity.magnitude * CharacterRigidBody.velocity.magnitude) * CharacterRigidBody.drag;
		Vector2 dragForceVector = dragForceMagnitude * -CharacterRigidBody.velocity.normalized;
		CharacterRigidBody.velocity += dragForceVector;

		if (CharacterRigidBody.velocity.magnitude < 0.1) {
			CharacterRigidBody.velocity = new Vector2 (0, 0);
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
    }

    public void MoveRight()
    {
        CharacterRigidBody.velocity += (new Vector2(moveAccel, 0) * Time.deltaTime);
    }
}
