using UnityEngine;

public class CrearPiramide : MonoBehaviour
{
    public float mitadBase = 1.5f;
    public float altura = 2.5f;

    void Start()
    {
        CrearMesh();
    }

    void CrearMesh()
    {
        Mesh mesh = new Mesh();

        // =========================
        // VERTICES
        // =========================

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, altura, 0),               // 0 - punta

            new Vector3(-mitadBase, 0,  mitadBase), // 1
            new Vector3( mitadBase, 0,  mitadBase), // 2
            new Vector3( mitadBase, 0, -mitadBase), // 3
            new Vector3(-mitadBase, 0, -mitadBase)  // 4
        };


        // =========================
        // TRIANGULOS
        // =========================

        int[] triangulos = new int[]
        {
            // Cara frontal
            0, 1, 2,

            // Cara derecha
            0, 2, 3,

            // Cara trasera
            0, 3, 4,

            // Cara izquierda
            0, 4, 1,

            // Base
            1, 4, 3,
            1, 3, 2
        };


        // =========================
        // ASIGNACION
        // =========================

        mesh.vertices = vertices;
        mesh.triangles = triangulos;

        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}