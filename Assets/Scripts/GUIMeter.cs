﻿using UnityEngine;
using System.Collections;

public class GUIMeter : MonoBehaviour
{

	Player player;
	float maxScale;
	float maxSize;
	
	public float CurrentFillPercent;
	public GameObject fill;
	
	void Start ()
	{
		// Cache the scale of the fill meter.
		maxScale = fill.transform.localScale.x;
		
		// Cache the size of the fillbar to be used to adjust the anchoring
		maxSize = transform.renderer.bounds.extents.x;
		player = (Player)GameObject.FindGameObjectWithTag (Tags.PLAYER).GetComponent<Player> ();
	}
	
	void Update ()
	{
		// Set scale to the current fill percentage
		fill.transform.localScale = new Vector3(CurrentFillPercent * maxScale, fill.transform.localScale.y, 
			fill.transform.localScale.z);
		
		// Adjust "anchoring" of the fill to always be to the left of the parent object
		float missingX = maxSize * (1-CurrentFillPercent) * maxScale;
		fill.transform.localPosition = new Vector3(-missingX, fill.transform.localPosition.y,
			fill.transform.localPosition.z);
	}
}
