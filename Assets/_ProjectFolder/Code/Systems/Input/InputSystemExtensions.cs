using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.InputSystem
{
    using EventSystems;
    
    public static class InputSystemExtensions
    {
        private static readonly List<RaycastResult> RaycastResults = new();
        private static readonly PointerEventData EventData = new(null);

        private static void RefreshUIElementsNonAlloc(Vector2 screenPosition)
        {
            if (EventSystem.current == null) return;
            
            EventData.position = screenPosition;
            RaycastResults.Clear();
            
            EventSystem.current.RaycastAll(EventData, RaycastResults);
        }
        private static Vector2 GetPointerScreenPosition() =>
            Pointer.current != null ? Pointer.current.position.ReadValue() : Vector2.zero;
        
        public static IReadOnlyList<RaycastResult> GetAllUIElements(Vector2 screenPosition)
        {
            RefreshUIElementsNonAlloc(screenPosition);
            return RaycastResults.ToArray();
        }
        public static GameObject GetTopUIElement(Vector2 screenPosition)
        {
            RefreshUIElementsNonAlloc(screenPosition);
            return RaycastResults.Count > 0 ? RaycastResults[0].gameObject : null;
        }
        
        public static bool IsPointerOverUI()
        {
            var screenPos = GetPointerScreenPosition();
            return IsPointerOverUI(screenPos);
        }
        public static bool IsPointerOverUI(Vector2 screenPosition)
        {
            RefreshUIElementsNonAlloc(screenPosition);
            return RaycastResults.Count > 0;
        }
        public static bool IsPointerOverUI(Vector2 screenPosition, string tag)
        {
            if (string.IsNullOrWhiteSpace(tag)) return false;
            
            RefreshUIElementsNonAlloc(screenPosition);
            return RaycastResults.Any(result => result.gameObject.CompareTag(tag));
        }
        public static bool IsPointerOverUI(Vector2 screenPosition, GameObject target)
        {
            if (target == null) return false;
 
            RefreshUIElementsNonAlloc(screenPosition);
            return RaycastResults.Any(result => result.gameObject == target || result.gameObject.transform.IsChildOf(target.transform));
        }
    }
}