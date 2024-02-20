using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public struct Behavior
    {
        //slower, attacks from a larger distance
        //faster, attacks from a shorter distance, deals more damage
        float speed;
        public float Speed
        {
            get { return speed; }
        }
        float range;
        public float Range
        {
            get { return range; }
        }
        float damage;
        public float Damage
        {
            get { return damage; }
        }

        EnemyType type;
        public void init(EnemyType ET)
        {
            switch (ET)
            {
                case EnemyType.slow:
                    speed = 3f;
                    range = 6f;
                    damage = 30f;
                    break;
                case EnemyType.fast:
                    speed = 7f;
                    range = 2f;
                    damage = 15f;
                    break;
                default:
                    break;
            }
        }
        public void attack()
        {
            //when in range, damage the player
            Player.instance.health -= damage * Time.deltaTime;
        }

    }


    public enum EnemyType
    {
        slow,
        fast
    }
}




