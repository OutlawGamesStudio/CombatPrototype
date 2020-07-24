using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterOverheadUI : MonoBehaviour
{
    private Quaternion m_OrigRotation;
    private Camera m_MainCamera;
    private GameObject m_OverheadUI;
    [SerializeField] private Scrollbar m_HealthBar;
    [SerializeField] private TextMeshProUGUI m_CharacterName;
    private NPC m_NPC;

    // Start is called before the first frame update
    private void Start()
    {
        m_NPC = transform.root.gameObject.GetComponent<NPC>();
        m_OverheadUI = transform.GetChild(0).gameObject;
        m_HealthBar = m_OverheadUI.GetComponentInChildren<Scrollbar>();
        m_CharacterName = m_OverheadUI.GetComponentInChildren<TextMeshProUGUI>();
        m_OrigRotation = transform.rotation;
        m_MainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateHealth();
        UpdateName();
        EnableHealthIfAble();
        FaceCamera();
    }

    private void EnableHealthIfAble()
    {
        if (m_NPC.CharacterStats.CurrentHealth <= 0)
        {
            m_OverheadUI.SetActive(false);
        }
        else
        {
            if (m_OverheadUI.activeSelf == false)
            {
                // Incase the NPC gets revived?
                m_OverheadUI.SetActive(true);
            }
        }
    }

    private void UpdateName()
    {
        m_CharacterName.text = m_NPC.CharacterStats.Name;
    }

    private void UpdateHealth()
    {
        m_HealthBar.size = m_NPC.CharacterStats.CurrentHealth / m_NPC.CharacterStats.MaxHealth;
    }

    private void FaceCamera()
    {
        transform.rotation = m_MainCamera.transform.rotation * m_OrigRotation;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
    }
}
