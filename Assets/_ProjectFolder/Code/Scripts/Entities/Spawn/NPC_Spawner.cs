using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    [SerializeField] private NPC_Sequencer sequencer;
    [SerializeField] private Transform spawnParent;
    [SerializeField] private NPC prefab;

    private void OnEnable() => sequencer.OnNewSoulLoaded += Spawn;
    private void OnDisable() => sequencer.OnNewSoulLoaded -= Spawn;
    
    private void Spawn(ScriptableSoul soul)
    {
        Instantiate(prefab, spawnParent).Setup(soul);
    }
}