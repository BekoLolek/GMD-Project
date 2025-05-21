using UnityEngine;
using TMPro;

public class ScoreChangePopup : MonoBehaviour
{
    public float floatSpeed = 30f;
    public float duration = 1f;

    private TextMeshProUGUI text;
    private RectTransform rectTransform;
    private float timer;

    public void Setup(int value)
    {
        if (text == null) text = GetComponent<TextMeshProUGUI>();
        text.text = (value > 0 ? "+" : "") + value.ToString();
        text.color = value >= 0 ? Color.green : Color.red;
    }

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0, floatSpeed * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer > duration)
            Destroy(gameObject);
    }
}
