﻿using ForgottenLegends.Character;
using ForgottenLegends.Core;
using ForgottenLegends.Utility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ForgottenLegends.Dialogue
{
    public class DialogueController : MonoBehaviour
    {
        #region Assignable Variables
        [SerializeField] private GameObject m_DialogueUI = null;
        [SerializeField] private GameObject m_DialogueChoices = null;
        [SerializeField] private Button m_DialogueButtonPrefab = null;
        #endregion

        #region Variables
        private float m_DialogueChoicesShownTime = 0f;
        private InputHandler m_InputHandler = null;
        private List<Button> m_DialogueButton = new List<Button>();
        private TextMeshProUGUI m_DialogueText = null;
        #endregion

        #region Methods
        private void Start()
        {
            m_InputHandler = InputHandler.Instance;
            m_DialogueText = m_DialogueUI.GetComponentInChildren<TextMeshProUGUI>();
            ShowDialogueUI(false);
        }

        private ActorDialogue GetActorDialogueByName(string npcName, string name)
        {
            return Resources.Load<ActorDialogue>($"Dialogue/{npcName}/{name}");
        }

        private void Update()
        {
            NPC npc = ClosestNPC();
            if (m_InputHandler.GetActivate() && ClosestNPC() != null && m_DialogueChoicesShownTime <= 0)
            {
                if (npc.ActorInfo.ActorDialogue != null && npc.ActorInfo.ActorDialogue == string.Empty)
                {
                    ActorDialogue actorDialogue = GetActorDialogueByName(npc.ActorInfo.CharacterStats.Name, npc.ActorInfo.ActorDialogue);
                    if (actorDialogue != null && actorDialogue.Dialogues.Length > 0)
                    {
                        for (int i = 0; i < actorDialogue.Dialogues.Length; i++)
                        {
                            CreateDialogueChoice(actorDialogue.Dialogues[i]);
                        }
                        ShowDialogueUI(true);
                        SetDialogueText(actorDialogue.StartingDialogue.DialogueText);
                        m_DialogueChoicesShownTime = 1f;
                        return;
                    }
                }
            }
            if (m_DialogueChoicesShownTime > 0)
            {
                m_DialogueChoicesShownTime -= Time.deltaTime;
            }
        }

        private void CreateDialogueChoice(Dialogue actorDialogue)
        {
            Button newButton = Instantiate(m_DialogueButtonPrefab);
            TextMeshProUGUI text = newButton.GetComponentInChildren<TextMeshProUGUI>();
            text.text = actorDialogue.DialogueName;
            newButton.onClick.AddListener(delegate
            {
                OnClick(actorDialogue);
            });
            newButton.transform.SetParent(m_DialogueChoices.transform, false);
            m_DialogueButton.Add(newButton);
        }

        private void ClearDialogue()
        {
            foreach (var button in m_DialogueButton)
            {
                Destroy(button.gameObject);
            }
            m_DialogueButton.Clear();
        }

        private void OnClick(Dialogue actorDialogue)
        {
            ClearDialogue();
            SetDialogueText(actorDialogue.DialogueText);
            if (actorDialogue.QuestDialogueChoices != null && actorDialogue.QuestDialogueChoices.Length > 0)
            {
                for (int i = 0; i < actorDialogue.QuestDialogueChoices.Length; i++)
                {
                    CreateDialogueChoice(actorDialogue.QuestDialogueChoices[i]);
                }
                return;
            }
            ExitDialogue();
        }

        private void ShowDialogueUI(bool toggle)
        {
            m_DialogueUI.SetActive(toggle);
            m_DialogueChoices.SetActive(toggle);
            MouseCursor.SetMouseVisible(toggle);
        }

        private void SetDialogueText(string text)
        {
            m_DialogueText.text = text;
        }

        private NPC ClosestNPC()
        {
            float closestDistance = 5f;
            NPC closestNPC = null;

            NPC[] npcs = FindObjectsOfType<NPC>();

            foreach (var npc in npcs)
            {
                float dist = Vector3.Distance(Player.Instance.transform.position, npc.transform.position);
                if (dist < closestDistance)
                {
                    closestDistance = dist;
                    closestNPC = npc;
                }
            }
            return closestNPC;
        }

        private void ExitDialogue(float time = 2f)
        {
            StartCoroutine(OnExitDialogue(time));
        }

        private IEnumerator OnExitDialogue(float seconds)
        {
            float curSeconds = 0;
            while (true)
            {
                yield return new WaitForEndOfFrame();
                curSeconds += Time.deltaTime;
                if (curSeconds >= seconds)
                {
                    ShowDialogueUI(false);
                    break;
                }
            }
        }
        #endregion
    }
}