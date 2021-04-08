using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

    public Text tapToStartText;
    private float myAlpha;
    private Color c;

	// Use this for initialization
	void Start () {

        c = tapToStartText.color;
       
	
	}
	
	// Update is called once per frame
	void Update () {

        float pingPong = Mathf.PingPong(Time.time, 1);
        myAlpha = Mathf.Lerp(0, 1, pingPong);

        c.a = myAlpha;
        tapToStartText.color = c;

        

        
        
	
	}
}
