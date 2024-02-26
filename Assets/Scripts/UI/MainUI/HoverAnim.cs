using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HoverAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    public float scaleChange = 1.1f;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale *= scaleChange;
        if(source.clip == null) return;
            source.Play();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
     public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
