using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score100 : MonoBehaviour
{
    public Animator animator;
    public GameObject go;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void Score100Corn()
    {
        gameObject.SetActive(true);
        StartCoroutine(ScoreAnimation());


    }
        

    private IEnumerator ScoreAnimation()
    {
        
        
        animator.SetTrigger("Float");
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

}
