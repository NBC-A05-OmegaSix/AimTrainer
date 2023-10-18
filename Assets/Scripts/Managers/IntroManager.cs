using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : Singleton<IntroManager>
{
    public Image logo;
    public Image title;
    public GameObject tutorial;

    private void Start()
    {
        Color logoColor = logo.color;
        Color titleColor = title.color;

        logoColor.a = 0f;
        titleColor.a = 0f;

        logo.color = logoColor;
        title.color = titleColor;

        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(FadeIn(logo));

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(FadeOut(logo));
        yield return StartCoroutine(FadeIn(title));

        yield return new WaitForSeconds(3f);

        tutorial.SetActive(true);
    }

    IEnumerator FadeIn(Graphic graphic, float duration = 1.0f)
    {
        Color color = graphic.color;
        while (color.a < 1.0f)
        {
            color.a += Time.deltaTime / duration;
            graphic.color = color;

            if (color.a >= 1.0f) break;

            yield return null;
        }
    }

    IEnumerator FadeOut(Graphic graphic, float duration = 1.0f)
    {
        Color color = graphic.color;
        while (color.a > 0)
        {
            color.a -= Time.deltaTime / duration;
            graphic.color = color;

            if (color.a <= 0) break;

            yield return null;
        }
    }
}