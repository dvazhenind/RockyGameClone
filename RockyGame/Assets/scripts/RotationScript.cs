using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

    public  int speed=200;
    public float rotateCount = 0;
    public GameControll gameControll;

    private void Start()
    {
        gameControll = GameObject.Find("GameControll").GetComponent<GameControll>();
    }



    void Update () {
        
        gameObject.transform.Rotate(0, 0, Time.deltaTime * speed);

        
        //Count number of turns
        float counter = gameObject.transform.rotation.z;
        if (counter < 0) counter *= -1;
        rotateCount += counter;        

        if (rotateCount/200>=1)
        {
            gameControll.GameOver();
        }
        
       
	}

   
}
