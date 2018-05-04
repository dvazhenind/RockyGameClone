using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public  GameObject activeStone;

    private Vector3 offSet;
    public float smoothSpeed;

	
	void Start () {
        
        offSet = transform.position - activeStone.transform.position;
		
	}
	
	void LateUpdate () {
        Vector3 desiredPosition = activeStone.transform.position + offSet;                        //position which is needed
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); //We will move camera smoothly
        transform.position = smoothedPosition;
	}
}
