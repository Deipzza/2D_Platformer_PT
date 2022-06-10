using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();
                ev.victoryZone = this;

                // Ejecución de una co-rutina para que en un tiempo determinado ejecute una función
                // En este caso, después de 2 segundos para ver la animación de victoria
                StartCoroutine(ExecuteAfterTime(2f));
            }
        }

        // Enumerador para cargar asíncrona y aditivamente la escena final
        IEnumerator ExecuteAfterTime(float time) {
            yield return new WaitForSeconds(time); // Esperar el tiempo indicado

            // Parar el juego y cargar la escena
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync("EndScene", LoadSceneMode.Additive);
        }
    }
}