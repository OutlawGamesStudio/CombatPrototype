using ForgottenLegends.Character;
using UnityEngine;

namespace ForgottenLegends.Combat
{
    [CreateAssetMenu(fileName = "MagicSpell", menuName = "Magic Spell")]
    public class MagicSpell : ScriptableObject
    {
        public GameObject spellObject;
        public bool isHostileSpell;
        public float manaCost;
        public WeaponStats weaponStats;

        public void OnTouchSpell(NPC npc)
        {
            if (isHostileSpell)
            {
                npc.OnWeaponDamage(weaponStats.BaseDamage);
                return;
            }
        }
    }
}