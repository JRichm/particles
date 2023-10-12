using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Draw : MonoBehaviour
{
    [SerializeField] int numParticles;
    [SerializeField] GameObject particlePrefab;

    private GameObject[] particles;

    private void Start() {
        for (int i = 0; i < numParticles; i++) {
            GameObject newParticle = Instantiate(particlePrefab);
            particles.Append(newParticle);
        }
    }

    private void Update() {
        for (int i = 0; i < particles.Length; i++) {

        }
    }
}

