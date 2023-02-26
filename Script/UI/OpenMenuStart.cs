using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuStart : MonoBehaviour
{
    public static bool StartMenu = false;

    public GameObject MenuStart;

    public void PressMenuStart()
    {
        if (StartMenu)
        {
            /*MenuStart.SetActive(true);
            StartMenu = false;*/
            MenuStart.SetActive(false);
            StartMenu = false;
        }
        else
        {
            /*MenuStart.SetActive(false);
            StartMenu = true;*/
            MenuStart.SetActive(true);
            StartMenu = true;
        }

    }
}
