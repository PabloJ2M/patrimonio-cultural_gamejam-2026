using UnityEngine;
using UnityEngine.EventSystems;

namespace UkuPacha
{
    public class DestinyManager : MonoBehaviour
    {
        [SerializeField] private DocumentManager documentManager;
        [SerializeField] private MarkingCard markingCard;
        
        [SerializeField] private Button3D hananPachaButton;
        [SerializeField] private Button3D kayPachaButton;

        private GameManager _gameManager;
        private NPC_Sequencer _sequencer;
        
        private void Awake()
        {
            _gameManager = FindFirstObjectByType<GameManager>();
            _sequencer = FindFirstObjectByType<NPC_Sequencer>();
            hananPachaButton.OnClick.AddListener(() => PullLever(true));
            kayPachaButton.OnClick.AddListener(() => PullLever(false));
        }

        private void OnEnable() => _sequencer.OnSoulReachTable += ResetButtons;
        private void OnDisable() => _sequencer.OnSoulReachTable -= ResetButtons;

        private void DisableButtons()
        {
            hananPachaButton.SetInteractable(false);
            kayPachaButton.SetInteractable(false);
        }
        private void ResetButtons()
        {
            hananPachaButton.SetInteractable(true);
            kayPachaButton.SetInteractable(true);
        }
        private void PullLever(bool toHananPacha)
        {
            if (!_sequencer) return;
            
            _gameManager?.CompleteInspection();
            _sequencer?.OnDestinyDecided(toHananPacha, markingCard.GetMarkedLaws);
            
            documentManager?.HideDocuments();
            markingCard?.ResetMarks();
            DisableButtons();
        }
    }
}