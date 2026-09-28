using Unity.Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private NPC_Sequencer sequencer;
    [SerializeField] private CinemachineVirtualCameraBase focusCamera;

    

    private void Awake()
    {
        focusCamera.enabled = false;
    }
    public void Inspection()
    {
        focusCamera.enabled = true;
    }

    public void CompleteInspection()
    {
        focusCamera.enabled = false;
        sequencer.LoadNextSoul();
    }
}