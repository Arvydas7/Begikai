using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Speed = 1f;
    [Range(-1f,10f)]
    private float offset;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

   
    void Update()
    {
        Speed = GameManager.Instance.currentScore/10f;
        offset += (Time.deltaTime * Speed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
