using System.Collections;
using UnityEngine;

public class GenerateStuff : MonoBehaviour
{
    public float secDelay;
    public float fullDuration;

    private float currentTime;
    private int _r;

    public GameObject thing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Generate());
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        _r = Random.Range(0, 100);
    }

    IEnumerator Generate()
    {
        float x = 0;
        
        switch (_r)
        {
            case < 50:
                x = -0.47f;
                break;
            
            case >= 50:
                x = 0.47f;
                break;
        }
        
        while (currentTime < fullDuration)
        {
            yield return new WaitForSeconds(secDelay);

            Instantiate(thing, new Vector3(transform.position.x + Random.Range(-0.47f, 0.47f), transform.position.y), transform.rotation);
        }
    }
}
