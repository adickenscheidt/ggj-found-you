using System;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour
{
    private bool _isHighlighted;
    private Color _normalColor;
    private readonly Color _interactColor = new Color(0.7f, 0, 0);
    protected SpriteRenderer SpriteRenderer;
    public bool IsActive { get; set; } = true;

    // Start is called before the first frame update
    public virtual void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        if (SpriteRenderer == null)
            SpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void HightlightAsInteractable(bool highlight)
    {
        if (SpriteRenderer == null)
            return;
        if (_isHighlighted == highlight)
            return;

        _isHighlighted = highlight;
        if (_isHighlighted)
        {
            _normalColor = SpriteRenderer.color;
            SpriteRenderer.color = _interactColor;
        }
        else
            SpriteRenderer.color = _normalColor;
    }

    protected void ResetColor()
    {
        SpriteRenderer.color = _normalColor;
    }

    public abstract void Interact();
}
