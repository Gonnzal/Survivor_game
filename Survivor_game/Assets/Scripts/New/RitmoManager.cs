using UnityEngine;

[System.Serializable]
public class RitmoEvento
{
    public float tiempoEnCancion;  // Segundo exacto del audio
    public float margen;           // Margen
    public bool yaActivado = false;
}

public class RitmoManager : MonoBehaviour
{
    public AudioSource audioSource;
    public RitmoEvento[] eventos;

    private RitmoEvento eventoActivo = null;
    private float tiempoVentana = 0f;

    private playerController player;

    void Update()
    {
        float tiempoActual = audioSource.time; // Tiempo real del audio

        // Comprobar si alg�n evento debe activarse
        foreach (var evento in eventos)
        {
            if (!evento.yaActivado && tiempoActual >= evento.tiempoEnCancion)
            {
                eventoActivo = evento;
                tiempoVentana = 0f;
                evento.yaActivado = true;
            }
        }
        /*
        if (eventoActivo != null)
        {
            tiempoVentana += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.danio = player.currentState.danioMax * 1.5f;
                eventoActivo = null;
            }
            else if (tiempoVentana >= eventoActivo.margen)
            {
                // Se acabo el tiempo, el jugador no pulso
                player.danio = player.currentState.danioMax;
                eventoActivo = null;
            }
        }
        */
    }
}
