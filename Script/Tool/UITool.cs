using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITool : MonoBehaviour
{
    
    public Image image;
    
    
    public void SetTool(Sprite s)
    {
        image.sprite = s;
    }
}
