using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 1f;

    void Update()
    {
        Vector2 offset = new Vector2(Time.time * scrollSpeed, 0);

        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
