using UnityEngine;

namespace ForgottenLegends.Combat
{
    [CreateAssetMenu(fileName = "Combat Animation", menuName = "Combat/Combat Animation")]
    public class CombatAnimation : ScriptableObject
    {
        public WeaponType WeaponType;
        public AnimationClip[] FastAttack;
        public AnimationClip[] StrongAttack;
    }
}