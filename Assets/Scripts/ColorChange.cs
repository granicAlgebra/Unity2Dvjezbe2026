using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_spriteRenderer == null)
            Debug.LogError("Na ovom objektu nema SpriteRenderera!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _spriteRenderer.color = Random.ColorHSV();
        }
    }
}
