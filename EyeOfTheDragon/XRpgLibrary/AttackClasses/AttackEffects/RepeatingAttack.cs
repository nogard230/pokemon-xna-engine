using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.PokemonClasses;

namespace XRpgLibrary.AttackClasses.AttackEffects
{
    public class RepeatingAttack : AttackEffect
    {
        int power;
        int times;
        bool guarenteed;
        public RepeatingAttack(int damage, int maxNumTimes, bool guarenteedMax, float effectPercentage)
            : base(effectPercentage)
        {
            times = maxNumTimes;
            guarenteed = guarenteedMax;
            power = damage;
        }

        public RepeatingAttack()
            : base(1f)
        {

        }

        public override void ApplyEffect(Pokemon user, Pokemon target, Attack attack)
        {
            if (guarenteed)
            {
                for (int i = 0; i < times; i++)
                {
                    target.damage(BattleCalculator.CalculateDamage(user, target, attack, power));
                }
            }
            else
            {
                Random r = new Random();
                float num = r.Next(1000) / 10f;
                int hitTimes;

                if (num < 37.5)
                {
                    hitTimes = 2;
                }
                else if (num < 75)
                {
                    hitTimes = 3;
                }
                else if (num < 87.5)
                {
                    hitTimes = 4;
                }
                else
                {
                    hitTimes = 5;
                }

                for (int i = 0; i < hitTimes; i++)
                {
                    target.damage(BattleCalculator.CalculateDamage(user, target, attack, power));
                }
            }
        }

        public override string ToString()
        {
            string toString = "Repeating Attack";
            toString += ", " + power;
            toString += ", " + times;
            toString += ", " + guarenteed;
            toString += ", " + effectPercentage;

            return toString;
        }
    }
}
