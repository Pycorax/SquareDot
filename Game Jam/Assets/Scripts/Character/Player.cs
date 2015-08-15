using UnityEngine;
using System.Collections;

public sealed class Player : Character, ICharacterTag
{
	// ICharacterTag
    [HideInInspector] 
    public string Tag { get { return tag; } }
    private string tag = "Player";

    // Advanced Attack (Dependent on Element)
    [Tooltip("Secondary Skill")] public AdvancedSkill Attack2Skill;

    // Public Variables
    public ELEMENT_TYPE Element = ELEMENT_TYPE.NORMAL_ELEMENT;

    #region Event Functions
    
        void Awake()
        {
            base.CharacterAwake();
        }

        void Update()
        {
            AttackSkill.UpdateCooldown();
            Attack2Skill.UpdateCooldown();
        }

    #endregion

    #region Member Functions

        // Action
        public override void Attack()
        {
            switch (Element)
            {
                case ELEMENT_TYPE.NORMAL_ELEMENT:

                    break;
                case ELEMENT_TYPE.FIRE_ELEMENT:

                    break;
                case ELEMENT_TYPE.WATER_ELEMENT:

                    break;
                case ELEMENT_TYPE.AIR_ELEMENT:

                    break;
            }

            // TODO: Set the projectile tag as Tag from ICharacterTag
        }

    #endregion  
}
