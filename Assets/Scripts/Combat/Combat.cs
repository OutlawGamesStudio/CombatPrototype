using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Fists,
    Sword,
    Bow,
    Spear,
    Other
};

public enum AttackType
{
    None,
    Dodge,
    Fast,
    Strong
};

public class Combat : AnimationScript
{
    private static Combat Instance;

    public static AudioSource AudioSource { get; set; }
    [SerializeField] private AudioSource SwingAudioSource = null;
    [SerializeField] private WeaponType m_WeaponType = WeaponType.Fists;
    private List<CombatScript> m_CombatScripts = new List<CombatScript>();

    private SwordCombat m_SwordCombat;
    private BowCombat m_BowCombat;
    private CombatBlock m_Block;
    private LockOn m_LockOn;
    private Dodge m_Dodge;
    public Sheath Sheath { get; private set; }

    public bool WeaponSheathed { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    protected override void Start()
    {
        base.Start();
        AudioSource = gameObject.AddComponent<AudioSource>();
        AudioSource.loop = false;
        m_SwordCombat = new SwordCombat(m_Animator, SwingAudioSource);
        m_BowCombat = new BowCombat(m_Animator);
        m_CombatScripts.Add(m_SwordCombat);
        m_CombatScripts.Add(m_BowCombat);

        m_Block = new CombatBlock(m_Animator);
        m_LockOn = new LockOn(m_Animator, transform);
        m_Dodge = new Dodge(m_Animator);
        Sheath = new Sheath(m_Animator, m_CombatScripts, AudioSource);
    }

    // Update is called once per frame
    private void Update()
    {
        Sheath.Execute();
        if (Player.Instance.CharacterStats.InCombat == true)
        {
            m_LockOn.Execute();
            m_Dodge.Execute();
            m_Block.Execute();
            foreach(var combatScript in m_CombatScripts)
            {
                if(combatScript.WeaponType == m_WeaponType)
                {
                    combatScript.Execute();
                    break;
                }
            }
        }
        foreach (var combatScript in m_CombatScripts)
        {
            if (combatScript.WeaponType == m_WeaponType)
            {
                combatScript.PostExecute();
                break;
            }
        }
        m_LockOn.PostExecute();
        Sheath.PostExecute();
    }

    public static bool GetCombat()
    {
        return !Instance.Sheath.IsSheathed;
    }
}
