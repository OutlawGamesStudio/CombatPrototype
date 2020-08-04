using ForgottenLegends.Character;
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
    #region Properties
    public static AudioSource AudioSource { get; set; }
    public static Sheath Sheath { get; private set; }
    public bool WeaponSheathed { get; private set; }
    #endregion

    #region Variables
    private static Combat Instance;

    [SerializeField] private AudioSource SwingAudioSource = null;
    [SerializeField] private WeaponType m_WeaponType = WeaponType.Fists;
    private List<CombatScript> m_CombatScripts = new List<CombatScript>();

    private SwordCombat m_SwordCombat;
    private BowCombat m_BowCombat;
    private SpearCombat m_SpearCombat;
    private FistCombat m_FistCombat;
    private MagicCombat m_MagicCombat;
    private CombatBlock m_Block;
    private LockOn m_LockOn;
    private Dodge m_Dodge;
    private SwitchWeapon m_SwitchWeapon;
    #endregion

    #region Methods
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
        m_SwordCombat = new SwordCombat(m_Animator, SwingAudioSource, this);
        m_BowCombat = new BowCombat(m_Animator, this);
        m_SpearCombat = new SpearCombat(m_Animator, this);
        m_FistCombat = new FistCombat(m_Animator, this);
        m_MagicCombat = new MagicCombat(m_Animator, this);
        m_CombatScripts.Add(m_SwordCombat);
        m_CombatScripts.Add(m_BowCombat);
        m_CombatScripts.Add(m_SpearCombat);
        m_CombatScripts.Add(m_FistCombat);

        m_Block = new CombatBlock(m_Animator, this);
        m_LockOn = new LockOn(m_Animator, transform, this);
        m_Dodge = new Dodge(m_Animator, this);
        Sheath = new Sheath(m_Animator, m_CombatScripts, AudioSource, this);
        m_SwitchWeapon = new SwitchWeapon(m_Animator, this);
    }

    // Update is called once per frame
    private void Update()
    {
        m_SwitchWeapon.Execute();
        Sheath.Execute();
        if (Player.Instance.ActorData.CharacterStats.InCombat == true)
        {
            m_LockOn.Execute();
            m_Dodge.Execute();
            m_Block.Execute();
            m_MagicCombat.Execute();
            foreach (var combatScript in m_CombatScripts)
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
        m_MagicCombat.PostExecute();
        m_LockOn.PostExecute();
        Sheath.PostExecute();
    }
    #endregion

    #region Static Methods
    public static bool GetCombat()
    {
        return !Sheath.IsSheathed;
    }

    public static void SetWeaponType(WeaponType weaponType)
    {
        Instance.m_WeaponType = weaponType;
    }
    #endregion
}
