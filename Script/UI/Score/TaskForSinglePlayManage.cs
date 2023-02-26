using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyPlatformer;

public class TaskForSinglePlayManage : MonoBehaviour
{
    int Corn;
    int Mango;
    int Durian;
    int MaxCorn;
    int MaxMango;
    int MaxDurian;

    [SerializeField] private TextMeshProUGUI textCorn;
    [SerializeField] private TextMeshProUGUI textMango;
    [SerializeField] private TextMeshProUGUI textDurian;
    

    // Start is called before the first frame update
    void Start()
    {
         Corn = 0;
         Mango = 0;
         Durian = 0;
         MaxCorn = 0;
         MaxMango = 0;
         MaxDurian = 0;

        float randomNumber = Random.Range(1, 4);
        if (randomNumber == 1)
        {
            MaxCorn = Random.Range(1, 5);
            MaxMango = Random.Range(1, 5);
            MaxDurian = Random.Range(1, 5);
            UpdateTaskCorn(Corn);
            UpdateTaskDurian(Durian);
            UpdateTaskMango(Mango);
        }
        else if (randomNumber == 2)
        {
            MaxCorn = Random.Range(3, 6);
            MaxMango = Random.Range(3, 6);
            UpdateTaskCorn(Corn);
            UpdateTaskMango(Mango);

        }
        else if (randomNumber == 3)
        {
            MaxCorn = Random.Range(3, 6);
            UpdateTaskCorn(Corn);
        }


    }
    void UpdateTaskCorn(int num)
    {
        textCorn.text = $"Corn : {num}/{MaxCorn}";
    }
    void UpdateTaskMango(int num)
    {
        textMango.text = $"Mango : {num}/{MaxMango}";
    }
    void UpdateTaskDurian(int num)
    {
        textDurian.text = $"Durian : {num}/{MaxDurian}";
    }
    private void Update()
    {
        if(GameManager.GameHasEnded == true) {
            ScoreManager.instance.IsFinishTask(CheckTask());
            
        }
    }

    public void AddToTask(string name)
    {
        if (name == "Corn")
        {
            Corn++;
            if (MaxCorn!=0)
            {
                UpdateTaskCorn(Corn);
            }
        }
        if (name == "Mango")
        {
            Mango++;
            if (MaxMango!=0)
            {
                UpdateTaskMango(Mango);
            }
        }
        if (name == "Durian")
        {
            Durian++;
            if (MaxDurian!=0)
            {
                UpdateTaskDurian(Durian);
            }
        }
    }

    bool CheckTask()
    {
        if (Corn>=MaxCorn&&
            Mango>=MaxMango&&
            Durian>=MaxDurian)
        {
            return true;
        }


        return false;
    }

   
}
