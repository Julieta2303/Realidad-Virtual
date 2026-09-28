using UnityEngine;
using UnityEngine.InputSystem;

public class RotacionFigura : MonoBehaviour
{
    public float velocidad = 90f;

    void Update()
    {
        float rotacionX = 0f;
        float rotacionY = 0f;

        // Flecha arriba
        if (Keyboard.current.upArrowKey.isPressed)
        {
            rotacionX = velocidad;
        }

        // Flecha abajo
        if (Keyboard.current.downArrowKey.isPressed)
        {
            rotacionX = -velocidad;
        }

        // Flecha izquierda
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            rotacionY = -velocidad;
        }

        // Flecha derecha
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            rotacionY = velocidad;
        }

        transform.Rotate(
            rotacionX * Time.deltaTime,
            rotacionY * Time.deltaTime,
            0f,
            Space.Self
        );
    }
}