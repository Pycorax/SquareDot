using UnityEngine;
using System.Collections;

/*
 * The object should have uniform scale in all dimensions
 */

public class Projectile : MonoBehaviour 
{
    // Public Fields
    public ELEMENT_TYPE Element { get { return element; } }

    // Private Variables
    private ELEMENT_TYPE element = ELEMENT_TYPE.NORMAL_ELEMENT;
    private Vector3 velocity = new Vector3();
    private float range = 0.0f;
    private Vector3 originalPos = new Vector3();
    private int damage = 0;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
        // Get the distance from original position
	    Vector3 deltaPos = transform.position - originalPos;
        if (deltaPos.sqrMagnitude > range * range)
	    {
	        // If the distance exceeds the range, kill it

	    }
	}

    public void Fire(Vector3 position, Vector3 direction, Skill skill)
    {
        transform.position = originalPos = position;
        transform.localScale = skill.Scale;
        velocity = skill.Speed * direction;
        element = skill.Element;
        range = skill.Range;

        damage = skill.Damage;
    }

    private void resetProjectile()
    {
        velocity = Vector3.zero;
    }
}
