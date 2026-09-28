using Unity.Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private NPC_Sequencer sequencer;
    [SerializeField] private CinemachineVirtualCameraBase focusCamera;
    
    private void Awake()
    {
        focusCamera.Priority.Value = -10;
    }
    public void Inspection()
    {
        focusCamera.Priority.Value = 100;
    }

    public void CompleteInspection()
    {
        focusCamera.Priority.Value = -10;
        sequencer.LoadNextSoul();
    }
}