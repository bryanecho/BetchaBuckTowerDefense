using UnityEngine;
using System.Collections;

public class ShrinkGrow : MonoBehaviour {
    //
    // Cyclically Scales object Bigger->Smaller->back to bigger to create "breathing" effect
    //

    public float MaxExpansion=1.0f;
    public float ExpansionSpeed =0.2f;
    float CurrentExpansion = 0.0f;   
    

	// Use this for initialization
	void Start () {
	CurrentExpansion =0.0f;   
	}
	
	// Update is called once per frame
	void Update () {
        float thisX=0.0f;
        float thisY=0.0f;

        thisX=this.transform.localScale.x;

        //change shrink/expand direction if beyond limit set by MaxExpansion'
        if (CurrentExpansion>MaxExpansion || CurrentExpansion<-MaxExpansion)
        {
            ExpansionSpeed = ExpansionSpeed * -1;
        }
        
        CurrentExpansion+=ExpansionSpeed;

        this.transform.localScale += new Vector3(CurrentExpansion * Time.deltaTime, CurrentExpansion * Time.deltaTime, 0);

	
	}
}
