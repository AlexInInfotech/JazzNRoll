
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using NUnit.Framework.Constraints;

public class BaffVisualization : MonoBehaviour
{
    private class BaffIcon
    {
        public GameObject gameObject = new GameObject();
        public string baffName;
    }
    [SerializeField] private RectTransform _targetElement;
    static RectTransform targetElement;
    static BaffIcon[] baffIcons;
    static byte activeBaffCount = 0;
    static Transform iconsContainer;
    static MonoBehaviour couroutiner;
    const float duration = 1.5f;
    void Start()
    {
        targetElement = _targetElement;
        couroutiner = this;
        iconsContainer = this.transform;
        baffIcons = new BaffIcon[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            baffIcons[i] = new BaffIcon();
            baffIcons[i].gameObject = transform.GetChild(i).gameObject;
            baffIcons[i].gameObject.SetActive(false);
        }
    }
    public static void ShowPointsByBaff(string baffName, int value)
    {
        byte i = 0;
        while (baffIcons[i].baffName != baffName)
            i++;
        Transform pointsText = baffIcons[i].gameObject.transform.GetChild(1);
        pointsText.GetComponent<TextMeshProUGUI>().text ="+"+ value.ToString();
        pointsText.gameObject.SetActive(true);
        pointsText.transform.SetParent(iconsContainer.parent);
        couroutiner.StartCoroutine(PointsAnimation(baffIcons[i].gameObject.transform, pointsText, value, pointsText.transform.position - baffIcons[i].gameObject.transform.position));
    }
    static IEnumerator PointsAnimation(Transform parent, Transform transform, int value, Vector3 offset)
    {
        yield return new WaitForSeconds(1f);
        Vector3 startWorldPos = transform.position;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;
            float smoothPercentage = Mathf.SmoothStep(0f, 1f, percentageComplete);
            transform.position = Vector3.Lerp(startWorldPos, targetElement.position, smoothPercentage);

            yield return null;
        }
        PointsManager.AddToScore(value);
        transform.SetParent(parent);
        transform.position = parent.position + offset;
        transform.gameObject.SetActive(false);
    }
    public static void AddBaffToList(BaffItem baffItem)
    {
        baffIcons[activeBaffCount].baffName = baffItem.baff.name;
        baffIcons[activeBaffCount].gameObject.GetComponent<Image>().sprite = baffItem.icon;
        baffIcons[activeBaffCount].gameObject.SetActive(true);
        baffIcons[activeBaffCount].gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = baffItem.description;
        activeBaffCount++;
        //baffIcons[activeBaffCount]
    }
    
}
