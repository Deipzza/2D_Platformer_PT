using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour {

    // Botón de cerrado del canvas
    public void BackScene() {
        SceneManager.UnloadSceneAsync("Scene2"); // Descarga la escena
    }
}
