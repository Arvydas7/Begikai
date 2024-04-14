using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [Range (0f,10f)]
    public float Speed = 0.5f;

    private float offset;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * Speed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
