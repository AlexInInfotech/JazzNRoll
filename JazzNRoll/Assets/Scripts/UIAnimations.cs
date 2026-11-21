using System;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using static DiceManager;
public class UIAnimations 
{
    public static MonoBehaviour staticScript;
    public static void Start(MonoBehaviour script)
    {
        staticScript = script;

    }
    public static void DrawTextToPoint(Transform textTransform, Transform targetPoint, Action callback, float duration = 1)
    {
        staticScript.StartCoroutine(Couroutine(textTransform, targetPoint, callback, duration));
    }
    private static IEnumerator Couroutine(Transform textTransform, Transform targetPoint, Action callback, float duration = 1)
    {
        yield return new WaitForSeconds(1f);
        Vector3 startWorldPos = textTransform.position;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;
            float smoothPercentage = Mathf.SmoothStep(0f, 1f, percentageComplete);
            textTransform.position = Vector3.Lerp(startWorldPos, targetPoint.position, smoothPercentage);

            yield return null;
        }
        textTransform.position = startWorldPos;
        textTransform.gameObject.SetActive(false);
        callback?.Invoke();
    }
    public static void TextChanging(TextMeshProUGUI textMesh, string[] texts, float delay, Action callback)
    {
        staticScript.StartCoroutine(TextCouroutine(textMesh, texts, delay, callback));
    }
    private static IEnumerator TextCouroutine(TextMeshProUGUI textMesh, string[] texts, float delay, Action callback)
    {
        for (int i = 0; i < texts.Length; i++)
        {   
            if (i < texts.Length )
            {
                yield return new WaitForSeconds(delay);
            }
            textMesh.text = texts[i];

            
        }
        callback?.Invoke();
    }
    //public static IEnumerator DrawTextToPoint( Transform textTransform, int value, Vector3 offset)
    //{
    //    yield return new WaitForSeconds(1f);
    //    Vector3 startWorldPos = textTransform.position;

    //    float elapsedTime = 0f;

    //    while (elapsedTime < duration)
    //    {
    //        elapsedTime += Time.deltaTime;
    //        float percentageComplete = elapsedTime / duration;
    //        float smoothPercentage = Mathf.SmoothStep(0f, 1f, percentageComplete);
    //        textTransform.position = Vector3.Lerp(startWorldPos, rolls.position, smoothPercentage);

    //        yield return null;
    //    }
    //    transform.SetParent(parent);
    //    transform.position = parent.position + offset;
    //    transform.gameObject.SetActive(false);
    //}
}
