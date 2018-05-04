    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHook : MonoBehaviour {

    public bool hasEntered, diamondCatch;   // Переменная будет проверять вошли ли руки в зону камня
    public bool catchDiamond;               // Попался ли алмаз

    private GameControll gameControll;      // для того, чтобы на прямую передовать значения
    
    void Start()
    {
        gameControll = GameObject.Find("GameControll").GetComponent<GameControll>();

        gameObject.transform.SetParent(GameObject.Find("RotationOfRocky").transform); //Закрепляем Рокки за крутилкой
    }


   

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if(collision.gameObject.tag == "stone")
        {
            gameControll.activeStone = collision.gameObject;            
            hasEntered = true;
            
        }
        else if(collision.gameObject.tag == "diamond")
        {
            diamondCatch = true;
            gameControll.catchedDiamond = collision.gameObject;

        }
        else if(collision.gameObject.tag == "crack")
        {
            gameControll.crack = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "stone")
        {
            hasEntered = false;
        }
    }

    void Update () {

        //Передаем переменные
        gameControll.hasEntered = hasEntered;       
        gameControll.diamondCatch = diamondCatch;
	}

    
}
