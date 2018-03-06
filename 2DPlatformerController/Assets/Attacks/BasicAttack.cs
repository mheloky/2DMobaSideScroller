using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Abilities
{
    public class BasicAttack : IAttack
    {
        public List<IDamagable> targets = new List<IDamagable>();
        private DamagerAttributes damagableAttributes=new DamagerAttributes();
        /*1+20smth what if we have tier system?
         * 2+20hp
         * 3+20dmg
         * 4+20armor
         * */
        public DamagerAttributes GetDamageAttributes()
        {
            return damagableAttributes;
        }

        public List<IDamagable> GetTargets()
        {
            return targets;
        }

        public void SetTargets(List<IDamagable> theTargets)
        {
            targets = theTargets;
        }
    }
}
