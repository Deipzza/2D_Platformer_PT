using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour {

    // Botón de inicio del juego
    public void StartGame() {
        SceneManager.LoadSceneAsync("SampleScene");
    }
    
    // Botón de cerrado del canvas
    public void BackScene() {
        SceneManager.UnloadSceneAsync("Scene2"); // Descarga la escena
    }
}
