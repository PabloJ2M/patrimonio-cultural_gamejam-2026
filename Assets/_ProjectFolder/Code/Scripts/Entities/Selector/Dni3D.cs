using UnityEngine;
using TMPro;

namespace UkuPacha
{
    public class Dni3D : MonoBehaviour
    {
        [SerializeField] private TextMeshPro nameTxt, ageTxt;
        [SerializeField] private TextMeshPro occupationTxt;
        [SerializeField] private MeshRenderer imageMesh;

        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        private MaterialPropertyBlock _block;

        private void Awake() => _block = new MaterialPropertyBlock();
        
        public void SetName(string value) => nameTxt.SetText(value);
        public void SetAge(int value) => ageTxt.SetText($"Edad: {value}");
        public void SetOccupation(string value) => occupationTxt.SetText($"Ocupación: {value}");
        public void SetImage(Texture2D value)
        {
            _block.SetTexture(MainTex, value);
            imageMesh.SetPropertyBlock(_block);
        }
    }
}