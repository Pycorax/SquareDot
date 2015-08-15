using UnityEngine;
using System.Collections;

public class Enemy : Character {

	public Vector2 FacingNormal = new Vector2(1 ,0);
	public const float ChangeFacingMaxTimer = 2.5f;
	public float ChangeFacingTimer = ChangeFacingMaxTimer;
	public bool ChangeFacing = false;

	void Awake () {
		base.CharacterAwake ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		CharacterRigidBody.velocity = FacingNormal * MoveAccel;
		base.CharacterUpdate ();

		ChangeFacingTimer -= Time.deltaTime;
		if (ChangeFacingTimer <= 0) {
			ChangeFacing = true;
			ChangeFacingTimer = ChangeFacingMaxTimer;
		}

		if (ChangeFacing) {
			FacingNormal = -FacingNormal;
			ChangeFacing = false;
		}
	}
}
