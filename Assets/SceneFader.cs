﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;

    void Start ()
    {
        StartCoroutine(FadeIn());
    } 

    public void FadeTo (string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    // Slowly dissapear
    IEnumerator FadeIn ()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            img.color = new Color(0f, 0f, 0f, curve.Evaluate(t));

            // Skip to the next frame
            yield return 0; 
        }
    }

    // Slowly appear
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            img.color = new Color(0f, 0f, 0f, curve.Evaluate(t));

            // Skip to the next frame
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
