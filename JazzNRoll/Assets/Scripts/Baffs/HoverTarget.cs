using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public class HoverTarget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject panel;
    private void Start()
    {
        panel = transform.GetChild(0).gameObject; 
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        panel.transform.SetParent(this.transform.parent.parent);
        panel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panel.transform.SetParent(this.transform);
        panel.SetActive(false);
    }
}
