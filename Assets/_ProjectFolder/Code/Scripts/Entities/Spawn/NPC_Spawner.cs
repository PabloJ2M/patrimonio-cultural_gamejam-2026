using UnityEngine;
using UnityEngine.Splines;

namespace UkuPacha
{
    public class NPC_Spawner : MonoBehaviour
    {
        [SerializeField] private NPC_Sequencer sequencer;
        [SerializeField] private Transform spawnParent;
        [SerializeField] private NPC prefab;

        private void OnEnable()
        {
            sequencer.OnNewSoulLoaded += Spawn;
            sequencer.OnDesitionTaken += Despawn;
        }
        private void OnDisable()
        {
            sequencer.OnNewSoulLoaded -= Spawn;
            sequencer.OnDesitionTaken -= Despawn;
        }
        
        private void Spawn(ScriptableSoul soul)
        {
            prefab.transform.position = spawnParent.position;
            prefab.gameObject.SetActive(true);
            prefab.Setup(soul);
            
            prefab.GetComponent<SplineAnimate>().Restart(true);
        }

        private void Despawn(bool sendToHeaven)
        {
            prefab.gameObject.SetActive(false);
        }
    }
}