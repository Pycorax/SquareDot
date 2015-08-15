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
    public bool SkillReady { get { return lastUsed > coolDown; } }

    // Public Vars to Expose to Inspector
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
    [Tooltip("A GameObject with a Projectile script that deals damage.")]
    public GameObject DamageGameObject;
    
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

	// Use this for initialization
	void Awake () 
    {
	    Init(SetSpeed, SetScale, SetDamage, SetElement, SetRange, SetCooldown);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    lastUsed += Time.deltaTime;
	}

    public void Init(float _speed, Vector3 _scale, int _damage, ELEMENT_TYPE _element, float _range, float _coolDown)
    {
        speed = _speed;
        scale = _scale;
        damage = _damage;
        element = _element;
        range = _range;
        coolDown = _coolDown;
    }

    public virtual bool Use(Vector3 usePosition, Vector3 useDirection)
    {
        // If cooled down
        if (SkillReady)
        {
            // Reset cooldown timer
            lastUsed = 0.0f;

            // Set the Variables
            DamageGameObject.GetComponent<Projectile>().Fire(usePosition, useDirection, this);
            Object.Instantiate(DamageGameObject);

            return true;
        }

        return false;
    }
}
