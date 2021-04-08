using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {

	public Image fadeImage;
	private float myAlpha;
	private Color c;

	// Use this for initialization
	void Awake () {

		c = fadeImage.color;
		myAlpha = 1;
		c.a = myAlpha;
	
	}
	
	// Update is called once per frame
	void Update () {

		fadeImage.color = c;
	
	}

	public float LoadSceneByTime(float Scene)
	{
		
	}
}
