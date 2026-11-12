using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public class HoverTarget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]GameObject hiddenObject;
    //private void Start()
    //{
    //    panel = transform.GetChild(0).gameObject; 
    //}
    public void OnPointerEnter(PointerEventData eventData)
    {
        hiddenObject.transform.SetParent(this.transform.parent.parent);
        hiddenObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hiddenObject.transform.SetParent(this.transform);
        hiddenObject.SetActive(false);
    }
}
