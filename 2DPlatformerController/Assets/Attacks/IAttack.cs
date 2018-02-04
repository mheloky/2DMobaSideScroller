using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Abilities
{
    public interface IAttack
    {
        DamagableAttributes GetDamagableAttributes();
        List<IDamagable> GetTargets();

    }
}
