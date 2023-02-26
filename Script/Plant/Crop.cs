using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Crop
{
	public AssetsCrop asset;

	public CropState state;


	
	private float growthLevel;
	private float waterLevel;
	

	public bool Grow(float amount)
	{
		if (state != CropState.Done || state != CropState.Dead)
		{

			growthLevel += (amount / (5f * asset.slowGrow));
		}
		if (state == CropState.Done)
		{

			growthLevel += (amount / (40f * asset.slowGrow));
		}

		if (growthLevel >= 1f)
		{
			
			growthLevel = 0f;
			return true;
		}


		return false;
	}



	public WaterState Dry(float amount)
	{
		waterLevel -= (amount / 8f);
		return GetWaterState();
	}

	public WaterState GetWaterState ()
	{
		if (waterLevel > -1f)
		{
			
			return WaterState.Watered;
		}
        else if (waterLevel > -2f)
        {
            
            return WaterState.Dry;
        }
        else
		{
			
			return WaterState.Dead;
		}
	}

	public void Harvest()
    {
		growthLevel = 0f;
		waterLevel = 1f;
	}

	public void Water ()
	{
		waterLevel = 1f;
	}

	public Crop (AssetsCrop a) {
		asset = a;
		state = CropState.Seed;
		growthLevel = 0f;
		waterLevel = 1f;
		
	}

	public bool HasCrop()
	{
		if (asset == null)
			return false;
		else
			return true;
	}

	public Sprite GetCropSprite()
	{
		if (asset == null)
			return null;

		switch (state)
		{
			case CropState.Seed:
				return asset.seedSprite;
			case CropState.Planted:
				return asset.plantSprite;
			case CropState.Dead:
				return asset.deadSprite;
			case CropState.Done:
				return asset.doneSprite;
		}

		Debug.LogError("WHAT?!");
		return asset.seedSprite;
	}

	public bool IsOnGround()
	{
		if (state == CropState.Planted && asset.seedIsOnGround)
			return true;
		else
			return false;
	}

	public Sprite GetDoneSprite()
	{
		return asset.doneSprite;
	}
	 public string GetName()
    {
        if (asset !=null)
        {
			return asset.name;
		}
		return null;
    }

}

public enum CropState
{
	Seed,
	Planted,
	Dead,
	Done
}

public enum WaterState
{
	Watered,
	Dry,
	Dead
}
