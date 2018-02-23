using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Abilities
{
    public class BasicAttack : IAttack
    {
        private List<IDamagable> targets = new List<IDamagable>();
        private DamagableAttributes damagableAttributes;
        /*1+20smth what if we have tier system?
         * 2+20hp
         * 3+20dmg
         * 4+20armor
         * */
        public DamagableAttributes GetDamagableAttributes()
        {
            return damagableAttributes;
        }

        public IDamagable[] GetTargets()
        {
            return targets.ToArray();
        }
    }
}
