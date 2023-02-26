using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatformer;
using UnityEngine.UI;

public class PlayerInteractController : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private TaskForSinglePlayManage task;
    [SerializeField] private UIScore scoreText;
    public KeyCode interactKey;
    public KeyCode switchToolKey;

    [SerializeField] private Tool tool;
    [SerializeField] private Tool Hand;
    [SerializeField] private Tool Hoe;
    [SerializeField] private Tool WaterCan;
    [SerializeField] private Tool SeedBag;
    Tool[] tools = new Tool[4] ;
    int listTools = 0;

    public UITool uiTool;

    private void Start()
    {
        
        tools[0] = Hand;
        tools[1] = Hoe;
        tools[2] = SeedBag;
        tools[3] = WaterCan;
        tool = tools[listTools];
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(interactKey))
        {
            if (target == null)
            {
                
                return;}

            DirtTiles dirt = target.GetComponent<DirtTiles>();
            if (dirt != null)
            {
                
                    dirt.Interact(tool,this);
                
                
            }

        }//
        if (Input.GetKeyDown(switchToolKey))
        {
            listTools++;
            SoundManager.instance.Play(SoundManager.SoundName.SwitchTool);
            
            if (listTools == 4)
            {
                listTools = 0;
            }

            tool = tools[listTools];
            SetTool();

        }

    }


    private void OnTriggerEnter2D(Collider2D collision) { 

        target = collision.gameObject;
    }

    void SetTool()
    {
        uiTool.SetTool(tool.sprite);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
           
            target = null;
        }
    }

    public void ScoreAdd(AssetsCrop crop)
    {
        scoreText.AddScore(crop.scorePoint);
        if (ScoreManager.instance.IsSoloPlay())
        {
            task.AddToTask(crop.name); 
        }
    }

    public void ScoreMinus()
    {
        scoreText.MinusScore(50);
    } 
}//
