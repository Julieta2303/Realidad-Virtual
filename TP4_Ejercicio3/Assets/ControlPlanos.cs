using UnityEngine;

public class ControlPlanos : MonoBehaviour
{
    public Transform plano1;
    public Transform plano2;
    public Transform piramide;
    public Material[] materialesPlano1;
    public Material[] materialesPlano2;

    public float velocidadRotacion = 60f;
    public float velocidadPiramide = 20f;

    int diseno = 0;

    int planoSeleccionado = 1;

    Vector3 velocidadPlano1 = Vector3.zero;
    Vector3 velocidadPlano2 = Vector3.zero;

    Renderer renderPlano1;
    Renderer renderPlano2;

    void Update()
    {
        // Rotación del plano 1
        plano1.Rotate(
            velocidadPlano1 * Time.deltaTime,
            Space.Self
        );

        // Rotación del plano 2
        plano2.Rotate(
            velocidadPlano2 * Time.deltaTime,
            Space.Self
        );

        // Rotación automática de la pirámide
        piramide.Rotate(
            Vector3.up * velocidadPiramide * Time.deltaTime,
            Space.Self
        );

        LeerTeclado();
    }


    void LeerTeclado()
    {
        // Selección de plano
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            planoSeleccionado = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            planoSeleccionado = 2;
        }


        // Flecha arriba
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (planoSeleccionado == 1)
            {
                velocidadPlano1 =
                    new Vector3(velocidadRotacion, 0, 0);
            }
            else
            {
                velocidadPlano2 =
                    new Vector3(0, velocidadRotacion, 0);
            }
        }


        // Flecha abajo
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (planoSeleccionado == 1)
            {
                velocidadPlano1 =
                    new Vector3(-velocidadRotacion, 0, 0);
            }
            else
            {
                velocidadPlano2 =
                    new Vector3(0, -velocidadRotacion, 0);
            }
        }


        // Flecha derecha
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (planoSeleccionado == 1)
            {
                velocidadPlano1 =
                    new Vector3(0, velocidadRotacion, 0);
            }
            else
            {
                velocidadPlano2 =
                    new Vector3(velocidadRotacion, 0, 0);
            }
        }


        // Flecha izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (planoSeleccionado == 1)
            {
                velocidadPlano1 =
                    new Vector3(0, -velocidadRotacion, 0);
            }
            else
            {
                velocidadPlano2 =
                    new Vector3(-velocidadRotacion, 0, 0);
            }
        }


        // Detener
        if (Input.GetKeyDown(KeyCode.D))
        {
            velocidadPlano1 = Vector3.zero;
            velocidadPlano2 = Vector3.zero;
        }


        // Reiniciar
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reiniciar();
        }
    }


    void Reiniciar()
    {
        velocidadPlano1 = Vector3.zero;
        velocidadPlano2 = Vector3.zero;

        plano1.localRotation = Quaternion.identity;
        plano2.localRotation = Quaternion.identity;

        diseno++;

        if (diseno >= materialesPlano1.Length)
        {
            diseno = 0;
        }

        renderPlano1.material =
            materialesPlano1[diseno];

        renderPlano2.material =
            materialesPlano2[diseno];
    }
    void Start()
    {
    renderPlano1 = plano1.GetComponent<Renderer>();
    renderPlano2 = plano2.GetComponent<Renderer>();
    }
}