using UnityEngine;

public class DepthScaler : MonoBehaviour
{

    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 1.2f;

    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        float t = Mathf.InverseLerp(minY, maxY, transform.position.y);
        float targetScale = Mathf.Lerp(minScale, maxScale, t);
        transform.localScale = new Vector3(targetScale, targetScale, targetScale);
    }

    // Update is called once per frame
    void Update()
    {
        Resize();
    }

    void Resize()
    {

        float t = Mathf.InverseLerp(minY, maxY, transform.position.y);
        float targetScale = Mathf.Lerp(minScale, maxScale, t);


        float currentScale = transform.localScale.x;
        float newScale = Mathf.Lerp(currentScale, targetScale, Time.deltaTime * 5f);

        transform.localScale = Vector3.one * newScale;

    }
}
