using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slider : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IEndDragHandler {

    [SerializeField]
    private Image slider;

    // Use this for initialization
    void Start()
    {
        slider.rectTransform.position = new Vector2(Screen.width / 2 , Screen.width *  0.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float getSpeed()
    {
        return (slider.rectTransform.position.x - 50) / (Screen.width - 100) + 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = eventData.position;
        if (position.x > 50 && position.x < Screen.width - 50)
        {
            Debug.Log("Slider");
            slider.rectTransform.position = new Vector2(position.x, slider.rectTransform.position.y);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnEndDrag(eventData);
    }
}
