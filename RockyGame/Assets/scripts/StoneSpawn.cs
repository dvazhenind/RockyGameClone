using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawn : MonoBehaviour {

    public GameObject stone, diamond, crack;
    public static int objectCount=0;
    private float distance = 4.2f;
    
    

    private float x, y, z;

	
	void Start () {

        var degrees = Random.value*180; //we want to spawn only in 180 , but at random angle        

        x = gameObject.transform.position.x - Mathf.Cos(degrees * Mathf.Deg2Rad) * distance; 
        y = gameObject.transform.position.y + Mathf.Sin(degrees* Mathf.Deg2Rad) * distance;
        z = gameObject.transform.position.z;

        Vector3 position = new Vector3(x, y, z);

        if (objectCount < 9)
        {
            Instantiate(stone, position, Quaternion.identity);
            
            
        }
        
        stone.transform.localScale = Vector3.one * Random.RandomRange(1.5f, 3.5f); ; //Different scales
        


        int randomStone = Random.Range(1, 10); //Случайно выбираем камень на котором будем спавнить алмаз

        if (randomStone == 4)
        {
            Instantiate(diamond, position, Quaternion.identity);
        }        

        objectCount++;

            
		
	}
	
}
