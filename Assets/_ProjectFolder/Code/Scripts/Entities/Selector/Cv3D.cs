using UnityEngine;
using TMPro;

namespace UkuPacha
{
    public class Cv3D : MonoBehaviour
    {
        [SerializeField] private TextMeshPro nameTxt, professionTxt;
        [SerializeField] private TextMeshPro experienceTxt;
        [SerializeField] private TextMeshPro crimes;
        
        public void SetName(string value) => nameTxt.SetText(value);
        public void SetProfession(string value) => professionTxt.SetText($"Profesión: {value}");
        public void SetExperience(int value) => experienceTxt.SetText($"Experiencia: {value}");
        public void SetCrimes(string value) => crimes.SetText($"Crímenes Detectados:\n{value}");
    }
}