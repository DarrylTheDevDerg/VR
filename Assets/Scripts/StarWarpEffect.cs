using UnityEngine;

public class StarWarpEffect : MonoBehaviour
{
    [Header("Referencia de Cámara")]
    [Tooltip("Arrastra aquí la Main Camera del XR Rig o la cámara del jugador")]
    public Transform cameraPOV;

    [Header("Configuración del efecto")]
    public bool seguirALaCamara = true;   // Si es true, el efecto se coloca delante de la cámara automáticamente

    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Stop();

        // Si no se asignó cámara, intentar encontrarla automáticamente
        if (cameraPOV == null)
        {
            if (Camera.main != null)
                cameraPOV = Camera.main.transform;
            else
                Debug.LogWarning("StarWarpEffect: No se asignó Camera POV y no se encontró Camera.main.");
        }
    }

    void LateUpdate()
    {
        // Si está activado, el efecto sigue a la cámara para que siempre rodee al usuario
        if (seguirALaCamara && cameraPOV != null)
        {
            transform.position = cameraPOV.position;
        }
    }

    public void ActivarSalto()
    {
        // Colocarlo delante de la cámara justo antes de empezar
        if (cameraPOV != null)
            transform.position = cameraPOV.position;

        ps.Play();
    }

    public void DetenerSalto()
    {
        ps.Stop();
    }
}