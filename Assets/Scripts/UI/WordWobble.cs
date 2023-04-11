using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordWobble : MonoBehaviour
{
	[SerializeField][Range(0f, 30f)] private float sinSize = 1.5f;
	[SerializeField][Range(0f, 30f)] private float cosSize = 2.5f;

	private TMP_Text textMesh;
    private Mesh mesh;
    private Vector3[] vertices;

    private List<int> wordIndexes;
    private List<int> wordLengths;

    private void Awake()
    {
        textMesh = GetComponent<TMP_Text>();

        wordIndexes = new List<int> { 0 };
        wordLengths = new List<int>();
    }

    private void Start()
    {
		string s = textMesh.text;
        for (int index = s.IndexOf(' '); index > -1; index = s.IndexOf(' ', index + 1)) 
        {
            wordLengths.Add(index - wordIndexes[wordIndexes.Count - 1]);
            wordIndexes.Add(index + 1);
        }
        wordLengths.Add(s.Length - wordIndexes[wordIndexes.Count - 1]);
	}

    private void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;

        for (int w = 0; w < wordIndexes.Count; w++) 
        {
            int wordIndex = wordIndexes[w];
            Vector3 offset = Wobble(Time.time + w);

			for (int i = 0; i < wordLengths[w]; i++)
			{
				TMP_CharacterInfo c = textMesh.textInfo.characterInfo[wordIndex + i];

				int index = c.vertexIndex;
				vertices[index] += offset;
				vertices[index + 1] += offset;
				vertices[index + 2] += offset;
				vertices[index + 3] += offset;
			}
		}

		mesh.vertices = vertices;
		textMesh.canvasRenderer.SetMesh(mesh);
	}

	private Vector2 Wobble(float time)
	{
		return new Vector2(Mathf.Sin(time * sinSize), Mathf.Cos(time * cosSize));
	}
}
