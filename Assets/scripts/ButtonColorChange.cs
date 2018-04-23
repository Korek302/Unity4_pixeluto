using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Button;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Button.GetComponent<Image>().color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Button.GetComponent<Image>().color = Color.white;
    }
}
