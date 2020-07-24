using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : Singleton<EnemyUI>
{
    [SerializeField] private GameObject m_EnemyUI;
    [SerializeField] private Scrollbar m_EnemyHealth;
    [SerializeField] private TextMeshProUGUI m_EnemyName;
    private NPC m_EnemyNPC;

    public void AssignEnemy(NPC enemyNPC)
    {
        if (enemyNPC == null)
        {
            m_EnemyUI.SetActive(false);
            return;
        }
        m_EnemyNPC = enemyNPC;
        SetEnemyName(enemyNPC.CharacterStats.Name);
        SetEnemyHealth(enemyNPC.CharacterStats.CurrentHealth, enemyNPC.CharacterStats.MaxHealth);
        m_EnemyUI.SetActive(true);
    }

    private void Update()
    {
        if (m_EnemyNPC == null)
        {
            return;
        }
        if (m_EnemyNPC.CharacterStats.CurrentHealth != m_EnemyHealth.size)
        {
            SetEnemyHealth(m_EnemyNPC.CharacterStats.CurrentHealth, m_EnemyNPC.CharacterStats.MaxHealth);
        }
    }

    private void SetEnemyName(string bossName)
    {
        m_EnemyName.text = bossName;
    }

    private void SetEnemyHealth(float bossHealth, float maxHealth)
    {
        m_EnemyHealth.size = bossHealth / maxHealth;
    }
}
