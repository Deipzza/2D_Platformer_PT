using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase para manejar los tres colliders
public class Colliders : MonoBehaviour {
    [SerializeField] Canvas canvas;
    public AudioSource music;
    GameObject player;

    void OnTriggerEnter2D(Collider2D col) {
        // Cuando el jugador colisione cada uno de los colliders ejecutará la función correspondiente
        if (name == "Collider_1" && col.name == "Player") {
            Collider1(col);
        }
        else if (name == "Collider_2" && col.name == "Player") {
            Collider2(col);
        }
        else if (name == "Collider_3" && col.name == "Player") {
            Collider3(col);
        }
    }

    void Collider1(Collider2D col) {
        // Desactivar el movimiento del jugador
        player = col.gameObject;
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Animator>().enabled = false;

        canvas.gameObject.SetActive(true); // Activar el canvas

        // Cambiar la música
        GameObject.Find("GameController").GetComponent<AudioSource>().enabled = false;
        music.Play();
    }

    void Collider2(Collider2D col) {
        // Se carga la escena asíncrona y aditivamente
        SceneManager.LoadSceneAsync("Scene2", LoadSceneMode.Additive);
    }

    void Collider3(Collider2D col) {
        // Desactivar la música por defecto y activar el sonido especial
        GameObject.Find("GameController").GetComponent<AudioSource>().enabled = false;
        if (!music.isPlaying) { // Para que no se inicie cada que el jugador interactúe con el collider
            music.Play();
        }
    }

    // Cerrar el canvas de Lorem ipsum
    public void CloseLorem() {
        // Volver a poner la música normal
        GameObject.Find("GameController").GetComponent<AudioSource>().enabled = true;
        music.Stop();

        // Devolverle el control al jugador
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Animator>().enabled = true;

        // Desactivar el collider para evitar errores si el jugador vuelve a pasar por él
        gameObject.SetActive(false);

        // Destruir la instancia del prefab del canvas
        Destroy(canvas.gameObject);
    }
}