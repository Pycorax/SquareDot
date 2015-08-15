using UnityEngine;
using System.Collections;

public class Enemy : Character, ICharacterTag 
{
    // ICharacterTag
    [HideInInspector]
    public string Tag { get { return tag; } }
    private string tag = "Enemy";

	public Vector2 FacingNormal = new Vector2(1 ,0);
	public const float ChangeFacingMaxTimer = 2.5f;
	public float ChangeFacingTimer = ChangeFacingMaxTimer;
	public Skill AttackSkill;
	public bool ChangeFacing = false;

    #region Event Functions

        void Awake () 
        {
		    base.CharacterAwake ();
	    }

	    // Use this for initialization
	    void Start () 
        {
	
	    }
	
	    // Update is called once per frame
	    void Update () 
        {

		    // Update enemy AI Position Depending its facing including friction and gravity
		    CharacterRigidBody.velocity = FacingNormal * MoveAccel;
		    base.CharacterUpdate ();

		    // Change enemy AI facing over time;
		    ChangeFacingTimer -= Time.deltaTime;
		    if (ChangeFacingTimer <= 0) {
			    ChangeFacing = true;
			    ChangeFacingTimer = ChangeFacingMaxTimer;
		    }

		    if (ChangeFacing) {
			    FacingNormal = -FacingNormal;
			    ChangeFacing = false;
		    }

		    // Check if Attack is ready to be used if so use attack
		    if (AttackSkill.SkillReady)
		    {
		        Attack();
                Debug.Log("Enemy Attacked!");
		    }
	    }

    #endregion

    #region Member Functions

        public override void Attack()
        {
            Vector3 Position = new Vector3(CharacterRigidBody.position.x, CharacterRigidBody.position.y, 0);
            Vector2 VelocityNormal2D = new Vector2(CharacterRigidBody.velocity.normalized.x, CharacterRigidBody.velocity.normalized.y);
            Vector3 VelocityNormal3D = new Vector3(VelocityNormal2D.x, VelocityNormal2D.y, 0);
            AttackSkill.Use(Position, VelocityNormal3D, tag);           // Set the Tag of the projectile to use Tag from ICharacterTag
        }

    #endregion
}
