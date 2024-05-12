using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMeshProFadeInOut : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro.text = "+25";
        StartCoroutine(FadeInOutText(0.5f));
    }

    IEnumerator FadeInOutText(float duration)
    {
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, (Time.time - startTime) / duration);
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);
            yield return null;
        }


        yield return new WaitForSeconds(1.0f);

        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, (Time.time - startTime) / duration);
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);
            yield return null;
        }

        Destroy(gameObject);
    }
}
