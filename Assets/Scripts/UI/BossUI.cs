using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : Singleton<BossUI>
{
    [SerializeField] private GameObject m_BossUI = null;
    [SerializeField] private Scrollbar m_BossHealth = null;
    [SerializeField] private TextMeshProUGUI m_BossName = null;
    private NPC m_BossNPC;

    public void AssignBoss(NPC bossNPC)
    {
        if(bossNPC == null)
        {
            m_BossUI.SetActive(false);
            return;
        }
        m_BossNPC = bossNPC;
        SetBossName(bossNPC.CharacterStats.Name);
        SetBossHealth(bossNPC.CharacterStats.CurrentHealth, bossNPC.CharacterStats.MaxHealth);
        m_BossUI.SetActive(true);
    }

    private void Update()
    {
        if(m_BossNPC == null)
        {
            return;
        }
        if(m_BossNPC.CharacterStats.CurrentHealth != m_BossHealth.size)
        {
            SetBossHealth(m_BossNPC.CharacterStats.CurrentHealth, m_BossNPC.CharacterStats.MaxHealth);
        }
    }

    private void SetBossName(string bossName)
    {
        m_BossName.text = bossName;
    }

    private void SetBossHealth(float bossHealth, float maxHealth)
    {
        m_BossHealth.size = bossHealth / maxHealth;
    }
}
