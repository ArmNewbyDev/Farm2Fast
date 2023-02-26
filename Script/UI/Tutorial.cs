using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject note;
    void Start()
    {
        if (note != null)
        {
            note.SetActive(false);
        }
    }
    public void TutorialNote()
    {
        if (note.activeSelf == true)
        {
            note.SetActive(false);
        }
        else
        {
            note.SetActive(true);
        }
    }

}
