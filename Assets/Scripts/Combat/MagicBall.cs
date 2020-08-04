using ForgottenLegends.Character;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public MagicSpell magicSpell;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<NPC>(out NPC npc))
        {
            magicSpell.OnTouchSpell(npc);
            Destroy(gameObject);
        }
    }
}