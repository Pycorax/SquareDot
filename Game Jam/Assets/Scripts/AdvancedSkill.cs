using System;
using UnityEngine;
using System.Collections;

public class AdvancedSkill : Skill
{
    public ELEMENT_TYPE Element = ELEMENT_TYPE.NORMAL_ELEMENT;

    public override bool Use(Vector3 usePosition, Vector3 useDirection, string userTag)
    {
        if (SkillReady)
        {
            // Reset cooldown timer
            base.lastUsed = 0.0f;

            throw new NotImplementedException();

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
                case ELEMENT_TYPE.NUM_ELEMENTS:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return true;
        }

        return false;
    }
}
