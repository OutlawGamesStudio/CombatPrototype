using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class MeleeWeapon : MonoBehaviour
{
    public static bool AttackAllowed { private get; set; }
    public static bool StrongAttack { private get; set; }
    public WeaponStats WeaponStats;
    private BoxCollider m_BoxCollider;
    private AudioClip BluntClip;
    private AudioClip HitClip;
    private AudioClip MissClip;
    AudioSource AudioSource;

    private void Start()
    {
        m_BoxCollider = GetComponent<BoxCollider>();
        m_BoxCollider.isTrigger = true;
        BluntClip = Resources.Load<AudioClip>("Audio/SFX/Bloody Punch");
        HitClip = Resources.Load<AudioClip>("Audio/SFX/Hit Body 1");
        MissClip = Resources.Load<AudioClip>("Audio/SFX/Miss Body");
        AudioSource = gameObject.AddComponent<AudioSource>();
        AudioSource.loop = false;
        AudioSource.clip = MissClip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(AttackAllowed == false)
        {
            return;
        }

        if(other.gameObject.TryGetComponent(out NPC npc))
        {
            AttackAllowed = false;
            if (StrongAttack)
            {
                AudioSource.clip = HitClip;
            }
            else
            {
                AudioSource.clip = BluntClip;
            }
            StrongAttack = false;
            npc.OnWeaponDamage(WeaponStats.BaseDamage);
            AudioSource.Play();
        }
    }
}
