using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControll : MonoBehaviour {

    public bool hasEntered, diamondCatch;                            // Будем принимть из DetectHook
    public Text scoresText, diamondScoreText, finalScore, HighScore;

    public GameObject rocky;
    public GameObject RotationOfRocky;
    public GameObject activeStone, catchedDiamond, crack, newStone;
    private GameObject[] stonesInScene;
    

    public int Scores =0;
    public int Diamonds =0;

    private bool gameOver = false;

    private void Update()
    {
        stonesInScene =  GameObject.FindGameObjectsWithTag("stone");
    }


    public void OnMouseDown()
    {

        if (!gameOver)
        {
            if (hasEntered)
            {
                Vector3 position = activeStone.transform.position;          
                RotationOfRocky.transform.position = position;              // make a new pivot point
                RotationOfRocky.GetComponent<RotationScript>().speed *= -1; // Reverse rotation

                RotationOfRocky.GetComponent<RotationScript>().rotateCount = 0f; //Refresh counter
                rocky.transform.localPosition = new Vector3(rocky.transform.localPosition.x * -1, rocky.transform.localPosition.y, rocky.transform.localPosition.z); //Switch hands

                activeStone.transform.GetChild(0).gameObject.SetActive(true); // Activate crack    
                

                Scores++;
                scoresText.text = Scores.ToString();



                if (diamondCatch)
                {
                    Diamonds++;
                    diamondScoreText.text = Diamonds.ToString();
                    Destroy(catchedDiamond);

                    rocky.GetComponent<DetectHook>().diamondCatch = false;

                }

                if (Scores% 5 == 0)
                {
                   StoneSpawn.objectCount = 0; //Making infinity stones
                   //Instantiate them at position of the last stone in the Scene
                   Instantiate(newStone, stonesInScene[stonesInScene.Length-1].transform.position, Quaternion.identity);

                }


            }
            else
            {
                StoneSpawn.objectCount = 0;                
                GameOver();
            }
        }
        else
        {
            Application.LoadLevel(Application.loadedLevel); //Restart All Scene
        }
        
    }

    public  void GameOver()
    {
        RotationOfRocky.GetComponent<RotationScript>().enabled = false; //Stop rotation,because we want normal falling object   
        rocky.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;   //Make body falls

        gameOver = true;                              // Now when mouse clicked - level restarts
        if(Scores>PlayerPrefs.GetInt("HighScore", 0)) // Setting highscore with the PlayerPrefs
        {
            PlayerPrefs.SetInt("HighScore", Scores);            
        }

        //GameOver Menu:

        finalScore.gameObject.SetActive(true);      
        HighScore.gameObject.SetActive(true);

        finalScore.text = finalScore.text + Scores.ToString();
        HighScore.text = HighScore.text + PlayerPrefs.GetInt("HighScore",0);

        

    }

    
}
