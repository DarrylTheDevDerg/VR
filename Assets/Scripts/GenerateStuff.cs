using System.Collections;
using UnityEngine;

public class GenerateStuff : MonoBehaviour
{
    public float secDelay;
    public float fullDuration;

    private float currentTime;

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
    }

    IEnumerator Generate()
    {
        while (currentTime < fullDuration)
        {
            yield return new WaitForSeconds(secDelay);

            Instantiate(thing);
        }
    }
}
