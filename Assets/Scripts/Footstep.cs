using UnityEngine;

public class Footstep : MonoBehaviour
{
    public float lastingTime = 20f;

    private SpriteRenderer _spriteRenderer;
    private float _runoutTime;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _runoutTime = Time.time + lastingTime;
    }

    void Update()
    {
        if (!_spriteRenderer.enabled)
            return;

        var restTimeMultiplicator = (_runoutTime - Time.time) / lastingTime;
        var oldColor = _spriteRenderer.color;
        _spriteRenderer.color = new Color(oldColor.r, oldColor.g, oldColor.b, Mathf.Max(0.01f, restTimeMultiplicator));
    }

    public void Show()
    {
        _spriteRenderer.enabled = true;
    }

    public void Hide()
    {
        _spriteRenderer.enabled = false;
    }
}
