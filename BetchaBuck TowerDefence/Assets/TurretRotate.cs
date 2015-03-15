using UnityEngine;
using System.Collections;

public class TurretRotate : MonoBehaviour {
    public float rotationSpeed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Rotate(0, 0,rotationSpeed * Time.deltaTime);

	
	}
}
