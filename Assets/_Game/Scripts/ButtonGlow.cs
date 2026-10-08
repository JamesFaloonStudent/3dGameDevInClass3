using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Button))]
public class ButtonGlow : MonoBehaviour
{
    public Image glow;
    public float speed = 2f;
    public float minAlpha = 0.3f;
    public float maxAlpha = 1f;
    public float scaleAmount = 0.08f;

    void Update()
    {
        float t = (Mathf.Sin(Time.unscaledTime * speed) + 1f) * 0.5f;

        Color c = glow.color;
        c.a = Mathf.Lerp(minAlpha, maxAlpha, t);
        glow.color = c;

        glow.rectTransform.localScale = Vector3.one * (1f + scaleAmount * t);
    }
}