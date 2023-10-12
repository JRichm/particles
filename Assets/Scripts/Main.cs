using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Main : MonoBehaviour {
    [SerializeField] int numParticles;
    [SerializeField] float spacing;
    [SerializeField] float boundBoxWidth;
    [SerializeField] float boundBoxHeight;
    [SerializeField] GameObject boundBox;
    [SerializeField] Material boundBoxMat;
    [SerializeField] GameObject particlePrefab;
    [SerializeField] GameObject particleParent;

    private GameObject[] particles;
    private Vector2 center;
    private LineRenderer boundBoxRenderer;


    private void Start() {
        boundBoxRenderer = gameObject.AddComponent<LineRenderer>();
        boundBoxRenderer.positionCount = 5;
        boundBoxRenderer.material = boundBoxMat;
        boundBoxRenderer.widthMultiplier = 10.0f;
        SpawnPoints();
    }

    private void Update() {
        ShowBoundingBox();
    }

    private void SpawnPoints() {
        int numRows = Mathf.CeilToInt(Mathf.Sqrt(numParticles));
        int numCols = Mathf.CeilToInt((float)numParticles / numRows);
        particles = new GameObject[numParticles];
        center = new Vector2(GetComponent<RectTransform>().rect.width / 2, GetComponent<RectTransform>().rect.height / 2);

        // Calculate the center offset for the particles
        Vector2 centerOffset = new Vector2((numCols - 1 ) * spacing / 0.2f, (numRows - 1) * spacing / 0.2f);
        Debug.Log(centerOffset);


        for (int row = 0; row < numRows; row++) {
            for (int col = 0; col < numCols; col++) {
                if (row * numCols + col >= numParticles) {
                    return;
                }

                // calculate position of each point
                float xOffset = col * spacing * 10;
                float yOffset = row * spacing * 10;

                Vector2 position = new Vector2(xOffset, yOffset);

                // Adjust the position to center the particle properly
                //Vector2 adjustedPosition = position + center - centerOffset;
                Vector2 adjustedPosition = position + center - centerOffset;

                GameObject newParticle = Instantiate(particlePrefab);
                newParticle.transform.SetParent(particleParent.transform);
                newParticle.transform.position = adjustedPosition;
                particles.Append(newParticle);
            }
        }
    }

    private void ShowBoundingBox() {
        Vector2[] corners = new Vector2[] {
                new Vector2(center.x - (boundBoxWidth / 2), center.y + (boundBoxHeight / 2)),
                new Vector2(center.x + (boundBoxWidth / 2), center.y + boundBoxHeight / 2),
                new Vector2(center.x + (boundBoxWidth / 2), center.y - boundBoxHeight / 2),
                new Vector2(center.x - (boundBoxWidth / 2), center.y - boundBoxHeight / 2)
        };

        for (int i = 0; i <= 4; i++) {
            if (i == 4) {
                boundBoxRenderer.SetPosition(i, corners[0]);
            }

            boundBoxRenderer.SetPosition(i, corners[i]);
        }
    }
}

