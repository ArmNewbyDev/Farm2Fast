using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crop", menuName = "Crop")]
public class AssetsCrop : ScriptableObject
{
	[Header("Image")]
		public Sprite seedSprite;
		public Sprite plantSprite;
		public Sprite doneSprite;
		public Sprite deadSprite;

	[Header("ScorePoint&SlowTimeForGlow")]
		public int scorePoint = 100;
		public float slowGrow = 1f;



	public bool seedIsOnGround = false;
	

}
