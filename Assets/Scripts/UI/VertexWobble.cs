using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VertexWobble : MonoBehaviour
{
	[SerializeField][Range(0f, 30f)] private float sinSize = 1.5f;
	[SerializeField][Range(0f, 30f)] private float cosSize = 2.5f;

	private TMP_Text textMesh;
    private Mesh mesh;
    private Vector3[] vertices;

    private void Awake()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;

        for(int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = Wobble(Time.time + i);

            vertices[i] = vertices[i] + offset;
        }
        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }

    private Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * sinSize), Mathf.Cos(time * cosSize));
    }
}
