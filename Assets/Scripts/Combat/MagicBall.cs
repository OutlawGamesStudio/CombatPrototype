using ForgottenLegends.Character;
using UnityEngine;

namespace ForgottenLegends.Combat
{
    public class MagicBall : MonoBehaviour
    {
        public MagicSpell magicSpell;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.TryGetComponent(out NPC npc))
            {
                magicSpell.OnTouchSpell(npc);
                Destroy(gameObject);
            }
        }
    }
}