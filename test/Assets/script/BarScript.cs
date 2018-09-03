using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarScript : MonoBehaviour {

    private float fillAmount;
   
    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Image lebenGrun;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       HandleBar();
	}

    
    private void HandleBar()
    {
        if (fillAmount != lebenGrun.fillAmount )
        {
            lebenGrun.fillAmount = Mathf.Lerp(lebenGrun.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
      
    }
    
    private float Map(float value, float inMin,float inMax,float outMin,float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
