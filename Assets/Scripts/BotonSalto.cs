using UnityEngine;

public class BotonSalto : MonoBehaviour
{
    [Header("Referencias")]
    public StarWarpEffect efectoSalto;
    public Renderer renderBoton;

    [Header("Referencia de Cámara (opcional)")]
    [Tooltip("Arrastra aquí la Main Camera del XR Rig. Solo si quieres que el botón se coloque delante del jugador.")]
    public Transform cameraPOV;

    [Header("Colores del botón")]
    public Color colorNormal = Color.red;
    public Color colorPresionado = Color.green;

    [Header("Configuración")]
    public float duracionSalto = 3f;

    private bool yaPresionado = false;

    void Start()
    {
        if (renderBoton != null)
            renderBoton.material.color = colorNormal;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !yaPresionado)
        {
            ActivarBoton();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!yaPresionado)
        {
            ActivarBoton();
        }
    }

    void ActivarBoton()
    {
        yaPresionado = true;

        if (renderBoton != null)
            renderBoton.material.color = colorPresionado;

        if (efectoSalto != null)
            efectoSalto.ActivarSalto();

        Invoke(nameof(TerminarSalto), duracionSalto);
    }

    void TerminarSalto()
    {
        if (efectoSalto != null)
            efectoSalto.DetenerSalto();

        if (renderBoton != null)
            renderBoton.material.color = colorNormal;

        yaPresionado = false;
    }
}