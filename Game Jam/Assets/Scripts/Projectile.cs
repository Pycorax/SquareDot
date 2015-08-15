using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

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
    private bool piercing;

    #region Event Functions

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Get the distance from original position
            Vector3 deltaPos = transform.position - originalPos;
            if (deltaPos.sqrMagnitude > range * range)
            {
                // If the distance exceeds the range, kill it
                Object.Destroy(gameObject);
            }
        }

        void OnCollsionEnter(Collision collision)
        {
            // Injure the other if it is not the source
            if (tag != collision.gameObject.tag)
            {
                // Get a handle to the Character component of the target
                Character target = collision.gameObject.GetComponent<Character>();

                try
                {
                    // Injure the target
                    target.TakeDamage(damage);
                }
                catch (NullReferenceException)
                {
                    // Not a Character
                }

                // Destroy this projectile if it cannot pierce
                if (!piercing)
                {
                    Object.Destroy(gameObject);
                }
            }  
        }

    #endregion

    public void Fire(Vector3 position, Vector3 direction, Skill skill)
    {
        transform.position = originalPos = position;
        transform.localScale = skill.Scale;
        velocity = skill.Speed * direction;
        element = skill.Element;
        range = skill.Range;
        tag = skill.tag;

        damage = skill.Damage;
    }

    private void resetProjectile()
    {
        velocity = Vector3.zero;
    }
}
