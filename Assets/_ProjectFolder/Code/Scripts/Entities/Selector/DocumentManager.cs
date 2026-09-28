using System.Linq;
using UnityEngine;

namespace UkuPacha
{
    public class DocumentManager : MonoBehaviour
    {
        [SerializeField] private Dni3D dniObject;
        [SerializeField] private Cv3D cvObject;
        
        private NPC_Sequencer _sequencer;
 
        private void Awake() => _sequencer = FindFirstObjectByType<NPC_Sequencer>();
        private void OnEnable()
        {
            _sequencer.OnNewSoulLoaded += ShowDocuments;
            _sequencer.OnSoulReachTable += DropItems;
        }
        private void OnDisable()
        {
            _sequencer.OnNewSoulLoaded -= ShowDocuments;
            _sequencer.OnSoulReachTable -= DropItems;
        }

        private void DropItems()
        {
            if (dniObject) dniObject.gameObject.SetActive(true);
            if (cvObject) cvObject.gameObject.SetActive(true);
        }
        private void ShowDocuments(ScriptableSoul soul)
        {
            UpdateDni(soul.dni);
            UpdateCv(soul.cv);
        }
        
        private void UpdateDni(DNIData dni)
        {
            dniObject?.SetName(dni.name);
            dniObject?.SetAge(dni.age);
            dniObject?.SetOccupation(dni.occupation);
            dniObject?.SetImage(dni.photo);
        }
        private void UpdateCv(CVData cv)
        {
            cvObject?.SetName(cv.name);
            cvObject?.SetProfession(cv.profession);
            cvObject?.SetExperience(cv.yearsOfExperience);
            
            var crimesDisplay = cv.crimes.Aggregate("", (current, crime) => current + $"• {crime.description}\n");
            cvObject?.SetCrimes(crimesDisplay);
        }

        public void HideDocuments()
        {
            if (dniObject) dniObject.gameObject.SetActive(false);
            if (cvObject) cvObject.gameObject.SetActive(false);
        }
    }
}
