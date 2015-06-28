using UnityEngine;
using System.Collections;

public class FadeOverLay : MonoBehaviour 
{
	float opacity = 0f;
	float OPACITY_INCREMENT = 0.25f;
	SpriteRenderer renderer;
	// Use this for initialization
	void Start () 
	{
		renderer = this.GetComponent<SpriteRenderer>();
		renderer.color = new Color(1f, 1f, 1f, opacity);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void fade()
	{
		opacity += OPACITY_INCREMENT;
		renderer.color = new Color(1f, 1f, 1f, opacity);
	}
}
