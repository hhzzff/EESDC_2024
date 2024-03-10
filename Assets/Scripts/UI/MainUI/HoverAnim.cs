using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HoverAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    public float sacleOrigin;
    public float scaleChange = 1.1f;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        scaleChange = 1.1f;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale *= scaleChange;
        if(source.clip == null) return;
            source.Play();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1)*sacleOrigin;
    }
     public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1)*sacleOrigin;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
