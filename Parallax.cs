using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float animationSpeed = 1f;
    

    public void Awake(){
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Update(){
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
