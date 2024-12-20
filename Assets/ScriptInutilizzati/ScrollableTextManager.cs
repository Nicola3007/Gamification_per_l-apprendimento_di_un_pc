using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollableTextManager : MonoBehaviour
{
    public RectTransform contentRect; // Il contenitore del testo
    public TMP_Text risposteText;     // Il componente TMP_Text

    void Start()
    {
        UpdateContentSize();
    }

    public void UpdateContentSize()
    {
        // Aggiorna l'altezza del contenitore in base al contenuto del testo
        float textHeight = risposteText.preferredHeight;
        Vector2 newSize = new Vector2(contentRect.sizeDelta.x, textHeight);
        contentRect.sizeDelta = newSize;
    }
}
