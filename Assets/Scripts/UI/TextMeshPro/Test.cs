using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private AdvancedText _text;
    [Multiline]
    [SerializeField] private string content;
    // Start is called before the first frame update
    void Start()
    {
        _text.ShowTextByTyping(content);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
