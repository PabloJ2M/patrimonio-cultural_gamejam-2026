using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TweenCanvasGroup dialogueTween;
    [SerializeField] private CursorHandler cursorHandler;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float charsPerSecond = 30f;

    [SerializeField] private UnityEvent onComplete;
    [SerializeField] private string[] messages;

    private int _index;
    private bool _isTyping;

    public void StartTutorial()
    {
        cursorHandler?.CursorUnLookForced();
        dialogueTween?.FadeIn();
        StartCoroutine(WriteText(messages[_index]));
    }
    public void Next()
    {
        _index++;

        if (_index >= messages.Length) {
            onComplete?.Invoke();
            dialogueTween?.FadeOut();
            cursorHandler?.CursorLookForced();
            return;
        }

        StopAllCoroutines();
        
        if (!_isTyping)
            StartCoroutine(WriteText(messages[_index]));
        else
            SetAllAlpha(255);
    }

    private IEnumerator WriteText(string message)
    {
        text?.SetText(message);
        text?.ForceMeshUpdate();

        int total = text.textInfo.characterCount;
        SetAllAlpha(0);

        float delay = 1f / charsPerSecond;
        var wait = new WaitForSeconds(delay);
        _isTyping = true;

        for (int i = 0; i < total; i++)
        {
            SetCharAlpha(i, 255);
            text?.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            yield return wait;
        }

        _isTyping = false;
    }

    private void SetAllAlpha(byte alpha)
    {
        TMP_TextInfo info = text.textInfo;
        for (int i = 0; i < info.characterCount; i++)
            SetCharAlpha(i, alpha);

        text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
    }
    private void SetCharAlpha(int index, byte alpha)
    {
        TMP_TextInfo info = text.textInfo;
        TMP_CharacterInfo charInfo = info.characterInfo[index];

        if (!charInfo.isVisible) return;

        int meshIndex = charInfo.materialReferenceIndex;
        int vertexIndex = charInfo.vertexIndex;
        Color32[] colors = info.meshInfo[meshIndex].colors32;

        colors[vertexIndex + 0].a = alpha;
        colors[vertexIndex + 1].a = alpha;
        colors[vertexIndex + 2].a = alpha;
        colors[vertexIndex + 3].a = alpha;
    }
}