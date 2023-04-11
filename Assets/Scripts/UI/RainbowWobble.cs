using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RainbowWobble : MonoBehaviour
{
    [SerializeField] private Gradient rainbow;
    [SerializeField] [Range(0f, 0.2f)] private float rainbowSize = 0.01f;

	private TMP_Text textMesh;
    private Mesh mesh;
    private Vector3[] vertices;
    private Color[] colors;

    private void Awake()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;
        colors = mesh.colors;

        for(int i = 0; i < vertices.Length; i++)
        {
            colors[i] = rainbow.Evaluate(Mathf.Repeat(Time.time + vertices[i].x * rainbowSize, 1f));
        }
        mesh.colors = colors;
        textMesh.canvasRenderer.SetMesh(mesh);
    }
}
