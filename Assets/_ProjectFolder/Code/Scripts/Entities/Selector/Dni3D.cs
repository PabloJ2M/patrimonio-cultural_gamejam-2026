using TMPro;
using UnityEngine;

namespace UkuPacha
{
    public class Dni3D : MonoBehaviour
    {
        [SerializeField] private TextMeshPro nameTxt, ageTxt;
        [SerializeField] private TextMeshPro occupationTxt;
        [SerializeField] private Material image;

        public void SetName(string value) => nameTxt.SetText(value);
        public void SetAge(int value) => ageTxt.SetText($"Edad: {value}");
        
        public void SetOccupation(string value) => occupationTxt.SetText($"Ocupación: {value}");
        public void SetImage(Texture2D value) => image.SetTexture("_MainTex", value);
    }
}