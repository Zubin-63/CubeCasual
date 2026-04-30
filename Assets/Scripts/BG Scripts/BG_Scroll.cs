using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroll : MonoBehaviour

{
    public float scrollSpeed = 0.3f;
    private MeshRenderer meshRenderer;
    private string mainTex ="_MainTex";
    // Start is called before the first frame update

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }
    void Scroll()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset(mainTex);
        offset.y += Time.deltaTime * scrollSpeed;
        meshRenderer.sharedMaterial.SetTextureOffset(mainTex, offset);

    }
}
