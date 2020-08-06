using ForgottenLegends.Character;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ForgottenLegends.Combat
{
    [Serializable]
    public class MagicCombat : CombatScript
    {
        private const float MAX_SPELL_TIME = 5f;
        public override WeaponType WeaponType => throw new NotImplementedException();
        private MagicSpell[] m_MagicSpells;
        private List<MagicSpellCast> m_MagicSpellCasts = new List<MagicSpellCast>();
        private float m_CurrentSpeed = 50f;
        private float m_CastRecently = 0f;
        private MagicSpell m_LastSpell;
        private int m_Index = 0;
        private Player m_Caster;
        private AudioClip m_SpellEquip;

        public MagicCombat(Animator animator, Combat combat) : base(animator, combat)
        {
            m_Caster = Player.Instance;
            m_SpellEquip = Resources.Load<AudioClip>("Audio/SFX/Magical Swoosh");
            m_MagicSpells = Resources.LoadAll<MagicSpell>("Weapons/Spells");
        }

        public override void Execute()
        {
            HandleSpells();
            if (m_InputHandler.GetMagic() && /*m_Caster.CharacterStats.CurrentMana > m_MagicSpells[m_Index].manaCost &&*/ m_CastRecently < 1)
            {
                MagicSpellCast magic = new MagicSpellCast();

                m_LastSpell = m_MagicSpells[m_Index];
                m_Caster.ActorInfo.CharacterStats.CurrentMana -= m_LastSpell.manaCost;
                magic.spellObject = UnityEngine.Object.Instantiate(m_LastSpell.spellObject);
                magic.spellObject.transform.rotation = Quaternion.Euler(0f, Player.Instance.transform.rotation.eulerAngles.y, 0f);
                magic.spellObject.transform.position = Player.Instance.transform.position;
                magic.spellObject.transform.position = new Vector3(magic.spellObject.transform.position.x, magic.spellObject.transform.position.y + 1f, magic.spellObject.transform.position.z) + magic.spellObject.transform.forward * 1.5f;
                magic.magicSpell = m_MagicSpells[m_Index];
                magic.origin = magic.spellObject.transform.position;
                m_MagicSpellCasts.Add(magic);
                m_CastRecently = 1.5f;
            }
        }

        private void HandleSpells()
        {
            HandleSpellCasts();
        }

        private void HandleSpellCasts()
        {
            for (int i = 0; i < m_MagicSpellCasts.Count; i++)
            {
                if (m_MagicSpellCasts[i].spellObject == null)
                {
                    RemoveSpellFromList(i);
                    continue;
                }

                IncreaseSpellTime(i);
                MoveForward(i);
                if (m_MagicSpellCasts[i].spellTime > MAX_SPELL_TIME)
                {
                    RemoveSpellFromList(i);
                }
            }
        }

        private void IncreaseSpellTime(int i)
        {
            m_MagicSpellCasts[i].spellTime += Time.deltaTime;
        }

        private void MoveForward(int i)
        {
            m_MagicSpellCasts[i].spellObject.transform.position += m_MagicSpellCasts[i].spellObject.transform.TransformDirection(Vector3.forward) * m_CurrentSpeed * Time.deltaTime;
        }

        private void DecrementHoldTime()
        {
            if (m_HoldTime > 0)
            {
                m_HoldTime -= Time.deltaTime;
            }
            if (m_CastRecently > 0)
            {
                m_CastRecently -= Time.deltaTime;
            }
        }

        private void RemoveSpellFromList(int i)
        {
            UnityEngine.Object.Destroy(m_MagicSpellCasts[i].spellObject);
            m_MagicSpellCasts.RemoveAt(i);
        }

        public override void OnWeaponSheath()
        {
            Combat.AudioSource.clip = m_SpellEquip;
        }

        public override void PostExecute()
        {
            DecrementHoldTime();
        }
    }
}