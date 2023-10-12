using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [SerializeField] float particleSize;
    [SerializeField] float particleRange;

    private LineRenderer lineRenderer;
    private RectTransform rectTransform;
    private int pointCount = 360;
    private Vector2 pos;
    private float gravity = 9.8f;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        rectTransform = GetComponent<RectTransform>();
        pos = new Vector2(rectTransform.position.x, rectTransform.position.y);
        lineRenderer.positionCount = pointCount;
    }

    private void Update() {
        for (int i = 0; i < pointCount; i++) {
            float angle = (i / (float)pointCount) * 360f;
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * particleRange;
            float y = Mathf.Sin(angle * Mathf.Deg2Rad) * particleRange;
            Vector2 point = new Vector3(x, y);
            lineRenderer.SetPosition(i, pos + point);
        }
    }
}

