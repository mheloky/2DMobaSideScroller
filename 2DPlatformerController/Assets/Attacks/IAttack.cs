using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Abilities
{
    public interface IAttack
    {
        DamagerAttributes GetDamageAttributes();
        List<IDamagable> GetTargets();
        void SetTargets(List<IDamagable> theTargets);
    }
}
