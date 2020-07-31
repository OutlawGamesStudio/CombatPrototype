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
    private AudioSource AudioSource;

    private void Start()
    {
        m_BoxCollider = GetComponent<BoxCollider>();
        m_BoxCollider.isTrigger = true;
        BluntClip = Resources.Load<AudioClip>("Audio/SFX/Bloody Punch");
        HitClip = Resources.Load<AudioClip>("Audio/SFX/Hit Body 1");
        AudioSource = gameObject.AddComponent<AudioSource>();
        AudioSource.loop = false;
        if(transform.root.gameObject.TryGetComponent<CapsuleCollider>(out CapsuleCollider capsuleCollider) == true)
        {
            Physics.IgnoreCollision(m_BoxCollider, capsuleCollider);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(AttackAllowed == false)
        {
            return;
        }

        if(other.gameObject.TryGetComponent(out Actor actor))
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
            actor.OnWeaponDamage(WeaponStats.BaseDamage);
            AudioSource.Play();
        }
    }
}
