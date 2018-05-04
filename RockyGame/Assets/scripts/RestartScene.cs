using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class RestartScene : MonoBehaviour {

    

    private void OnMouseDown()
    {
        Application.LoadLevel("Application.loadedlevel");
    }
}
