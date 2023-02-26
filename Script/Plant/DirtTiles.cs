using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatformer;

public class DirtTiles : MonoBehaviour
{
	public Crop crop;
	[SerializeField] private Crop cornSeed;
	[SerializeField] private Crop mangoSeed;
	[SerializeField] private Crop durianSeed;

	public Score100 score;
	public bool needsPlowing = true;

	public SpriteRenderer overlay;
	public Sprite littleDirt;
	public GameObject WaterDrop;


	public string OngroundLayer;
	public string CropLayer;

	public bool Task = false;

	private void Start()
	{
		if (needsPlowing)
		{
			AddDirt();
		}
		
	}

	private void Update()
	{
		
		if (crop.HasCrop())
		{

			if (crop.state == CropState.Seed)
			{
				bool isDone = crop.Grow(Time.deltaTime);
				if (isDone)
				{
					
					crop.state = CropState.Planted;
					Debug.Log("I'm Plant!");

					SoundManager.instance.Play(SoundManager.SoundName.Grow);
					UpdateSprite();
				}
                else
                {
					WaterDrain();
                }

			}

			if (crop.state == CropState.Planted)
			{

				bool isDone = crop.Grow(Time.deltaTime);
				if (isDone)
				{
					
					crop.state = CropState.Done;
					Debug.Log("Im Done");

					SoundManager.instance.Play(SoundManager.SoundName.Grow);
					UpdateSprite();
				}
				else
				{
					WaterDrain();
				}

			}

			if (crop.state == CropState.Done)
			{

				bool isDone = crop.Grow(Time.deltaTime);//,crop.state);
				if (isDone )
				{
					
					crop.state = CropState.Dead;
					Debug.Log("Im Dead");

					SoundManager.instance.Play(SoundManager.SoundName.Grow);
					UpdateSprite();
                }
                else
                {
					WaterDrain();
				}

			}
            
		}
	}


	public void Interact(Tool t,PlayerInteractController player)
    {
        if (needsPlowing == false)
        {
			if (crop.HasCrop() && t.toolType == ToolType.Hands)//|| t == null)
			{

				HarvestCrop(player);
				
				return;
			}
			

			if (t.toolType != ToolType.SeedsBag&&crop.asset==null)
			{
				Debug.Log("Need Seeds.");
				return;
			}


			else if (t.toolType == ToolType.SeedsBag&&crop.asset==null) {

				if (t.name == "CornSeeds")
				{
					float randomNumber = Random.Range(1, 4);
					Debug.Log(randomNumber);
					if (randomNumber == 1)
					{
						crop = cornSeed;
					}
					else if (randomNumber == 2)
					{
						crop = durianSeed;
					}
					else if (randomNumber == 3)
					{
						crop = mangoSeed;
					}
					crop.state = CropState.Seed;
					UpdateSprite();
					SoundManager.instance.Play(SoundManager.SoundName.PlantedSeed);
				}

				return;
			}

            if (t.toolType == ToolType.Watercan)
            {
				crop.Water();
				Debug.Log("Water");
				SoundManager.instance.Play(SoundManager.SoundName.Water);
				return;
            }

		}
        if (needsPlowing == true)
        {
            if (t.toolType == ToolType.Plow)
            {
				Plow();
            }
            else
            {
				Debug.Log("Need Plowing First");
            }
        }
   	}//

	void HarvestCrop(PlayerInteractController player)
	{
		if (crop.state == CropState.Done || crop.state == CropState.Dead)
		{
			
			crop.Harvest();
			
            if (crop.state == CropState.Done)
            {
				Debug.Log("Done");
				UpdateScore100(player);
				
			}
			if (crop.state == CropState.Dead)
			{
				SoundManager.instance.Play(SoundManager.SoundName.FailedCrop);
				player.ScoreMinus();
			}
			crop = new Crop(null);
			UnPlow();
		}
	}

	void WaterDrain()
    {
		if (crop.state == CropState.Done)
		{

			WaterDrop.SetActive(false);

		}
		else {
			WaterState state = crop.Dry(Time.deltaTime);
			if (state == WaterState.Watered)
			{

				WaterDrop.SetActive(false);
			}
			if (state == WaterState.Dry)
			{

				WaterDrop.SetActive(true);
			}
			if (state == WaterState.Dead)
			{
				crop.state = CropState.Dead;
				UpdateSprite();
				WaterDrop.SetActive(false);
			}
		}
        
	}
	void UnPlow()
    {
		needsPlowing = true;
		AddDirt();
	}

	void Plow()
	{
		SoundManager.instance.Play(SoundManager.SoundName.Plow);
		overlay.sprite = null;
		needsPlowing = false;
	}

	void AddDirt()
	{
		overlay.sprite = littleDirt;
		overlay.sortingLayerName = OngroundLayer;
	}

	void UpdateScore100(PlayerInteractController player)
    {
		SoundManager.instance.Play(SoundManager.SoundName.ScoreUp);
		score.Score100Corn();
		player.ScoreAdd(crop.asset);
	}
	void UpdateSprite()
	{
		overlay.sprite = crop.GetCropSprite();
		if (crop.IsOnGround())
		{
			overlay.sortingLayerName = OngroundLayer;
		}
		else
		{
			overlay.sortingLayerName = CropLayer;
		}
	}

}
