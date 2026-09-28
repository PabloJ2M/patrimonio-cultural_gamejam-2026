using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UkuPacha
{
    public class DestinyManager : MonoBehaviour
    {
        [SerializeField] private MarkingCard markingCard;
        [SerializeField] private Button3D hananPachaButton;
        [SerializeField] private Button3D kayPachaButton;

        private GameManager _manager;
        private NPC_Sequencer _sequencer;
        
        private void Awake()
        {
            _sequencer = FindFirstObjectByType<NPC_Sequencer>();
            hananPachaButton.OnClick.AddListener(() => PullLever(hananPachaButton, true));
            kayPachaButton.OnClick.AddListener(() => PullLever(kayPachaButton, false));
        }

        private void OnEnable() => _sequencer.OnNewSoulLoaded += ResetButtons;
        private void OnDisable() => _sequencer.OnNewSoulLoaded -= ResetButtons;

        private void ResetButtons(ScriptableSoul soul)
        {
            hananPachaButton.SetInteractable(true);
            kayPachaButton.SetInteractable(true);
        }
        private void PullLever(Button3D button, bool toHananPacha)
        {
            if (!_sequencer) return;
            
            _sequencer.OnDestinyDecided(toHananPacha, markingCard.GetMarkedLaws);
            markingCard.ResetMarks();
            
            button.SetInteractable(false);
        }
    }
}