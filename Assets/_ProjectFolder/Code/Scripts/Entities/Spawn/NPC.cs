using UnityEngine;

namespace UkuPacha
{
    public class NPC : MonoBehaviour
    {
        private GameObject _mesh;
        
        public void Setup(ScriptableSoul soul)
        {
            if (_mesh)
                Destroy(_mesh);

            _mesh = Instantiate(soul.prefab, transform);
            _mesh.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
    }
}