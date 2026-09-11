using System.Collections;
using UnityEngine;

public class GenerateStuff : MonoBehaviour
{
    public float secDelay;
    public float fullDuration;
    public float setX;

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
        while (currentTime < fullDuration)
        {
            yield return new WaitForSeconds(secDelay);

            switch (_r)
            {
                case < 50:
                    Instantiate(thing, new Vector3(transform.position.x + setX, transform.position.y, transform.position.z), transform.rotation);
                    break;
                
                case >= 50:
                    Instantiate(thing, new Vector3(transform.position.x - setX, transform.position.y, transform.position.z), transform.rotation);
                    break;
            }
            
        }
    }
}
