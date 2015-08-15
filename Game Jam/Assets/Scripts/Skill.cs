using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour
{
    // Public Fields
    public int Damage {get { return damage; }}
    public ELEMENT_TYPE Element {get { return element; }}
    public float Speed{ get { return speed;}}
    public Vector3 Scale{ get { return scale; }}
    public float Range{ get { return range; }}
    public bool Piercing { get { return piercing; } }
    public bool SkillReady { get { return lastUsed > coolDown; } }      // Returns true if the skill is ready to be used (Cooled down)

    /* 
     * Public Vars to Expose to Inspector
     *  - These Variables will never be used after Start() has been called
     */
    // -- Transforms
    public float SetSpeed;
    public Vector3 SetScale;
    // -- Damage
    public int SetDamage = 0;
    public ELEMENT_TYPE SetElement = ELEMENT_TYPE.NORMAL_ELEMENT;
    // -- Range
    public float SetRange = 0.0f;
    // -- CoolDown
    public float SetCooldown = 0.0f;
    // -- Projectile
    [Tooltip("A GameObject with a Projectile script that deals damage. It should have a uniform scale in all dimensions.")]
    public Projectile DamageGameObject;
    // -- Piercing
    [Tooltip("When set to true, a piercing skill can hit more than 1 target.")]
    public bool SetPiercing = false;
    
    // Private Vars
    // -- Transforms
    private float speed;
    private Vector3 scale;
    // -- Damage
    private int damage = 0;
    private ELEMENT_TYPE element = ELEMENT_TYPE.NORMAL_ELEMENT;
    // -- Range
    private float range = 0.0f;
    // -- CoolDown
    private float coolDown = 0.0f;
    protected float lastUsed = 0.0f;
    // -- Piercing
    private bool piercing = false;

	// Use this for initialization
	void Awake () 
    {
	    Init(SetSpeed, SetScale, SetDamage, SetElement, SetRange, SetCooldown, SetPiercing);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    lastUsed += Time.deltaTime;
	}

    public void Init(float _speed, Vector3 _scale, int _damage, ELEMENT_TYPE _element, float _range, float _coolDown, bool _piercing)
    {
        speed = _speed;
        scale = _scale;
        damage = _damage;
        element = _element;
        range = _range;
        coolDown = _coolDown;
        piercing = _piercing;
    }

    public virtual bool Use(Vector3 usePosition, Vector3 useDirection, string userTag)
    {
        // If cooled down
        if (SkillReady)
        {
            // Reset cooldown timer
            lastUsed = 0.0f;

            // Set the Variables
            DamageGameObject.GetComponent<Projectile>().Fire(usePosition, useDirection, this);
            DamageGameObject.tag = userTag;
            Object.Instantiate(DamageGameObject);

            return true;
        }

        return false;
    }
}
