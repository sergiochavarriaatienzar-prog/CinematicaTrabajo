using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
        public GameObject particlePrefab;

        public int numeroParticulas = 10;
        public float vInicial = 5f;
        public float angInicial = 45f;
        public float tiempoVida = 5f;
        public float gravedad = -9.8f;

        public List<GameObject> particles = new List<GameObject>();

    public void CreateParticleExplosion()
    {
        for (int i = 0; i < numeroParticulas; i++)
        {
            GameObject p = Instantiate(particlePrefab, transform.position, Quaternion.identity);

            Particle particleScript = p.GetComponent<Particle>();

            particleScript.vInicial = vInicial + Random.Range(-1f, 40f);
            particleScript.angInicial = Random.Range(-180, 180);

            particleScript.tiempoVidaMax = tiempoVida + Random.Range(-1f, 10f);
            particleScript.gravedad = gravedad;

            particleScript.tiempoParticulaAct = 0f;
            particleScript.posicionInicial = p.transform.position;

            particles.Add(p);
        }
    }

    public void UpdateParticlePosition(Particle p, float time)
    {
        p.tiempoParticulaAct += time;

        float angleRad = p.angInicial * Mathf.Deg2Rad;

        float x = p.vInicial * Mathf.Cos(angleRad) * p.tiempoParticulaAct;
        float y = p.vInicial * Mathf.Sin(angleRad) * p.tiempoParticulaAct +
                  0.5f * p.gravedad * p.tiempoParticulaAct * p.tiempoParticulaAct;

        Vector3 nuevaPos = p.posicionInicial + new Vector3(x, y, 0);

        p.transform.position = nuevaPos;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateParticleExplosion();
        }

        for (int i = particles.Count - 1; i >= 0; i--)
        {
            Particle p = particles[i].GetComponent<Particle>();

            UpdateParticlePosition(p, Time.deltaTime);

            if (p.tiempoParticulaAct > p.tiempoVidaMax)
            {
                Destroy(particles[i]);
                particles.RemoveAt(i);
            }
        }
    }
}



