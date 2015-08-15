using UnityEngine;
using System.Collections;

public sealed class Player : Character 
{
    // Advanced Attack (Dependent on Element)
    [Tooltip("Secondary Skill")] public AdvancedSkill Attack2Skill;

    // Public Variables
    public ELEMENT_TYPE Element = ELEMENT_TYPE.NORMAL_ELEMENT;

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
    }
}
