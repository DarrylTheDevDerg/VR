using System.Collections;
using UnityEngine;

public class MaterialManip : MonoBehaviour
{
    public MeshRenderer mat;
    public Color change;
    public bool canFade;

    public bool debug;

    public float fadeSpeed;

    private Color _orig;
    private bool _hasFaded, _inProcess;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _orig = mat.material.color;
    }
    
    IEnumerator ColorManip(Color newColor)
    {
        _inProcess = true;
        
        Color orig = mat.material.color;
        Color target = newColor;

        float elapsed = 0f;

        while (elapsed < fadeSpeed)
        {
            mat.material.color = Color.Lerp(orig, target, elapsed / fadeSpeed);
            
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        mat.material.color = newColor;
        _hasFaded = !_hasFaded;
        
        _inProcess = false;
    }
    
    public void StartFade()
    {
        StartCoroutine(_hasFaded ? ColorManip(_orig) : ColorManip(change));
    }
}
