using System;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour
{
    private bool _isInteractable;
    private Color _normalColor;
    private readonly Color _interactColor = new Color(0.7f, 0, 0);
    protected SpriteRenderer SpriteRenderer;
    protected Victim Victim;

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
        if (_isInteractable == highlight)
            return;

        _isInteractable = highlight;
        if (_isInteractable)
        {
            _normalColor = SpriteRenderer.color;
            SpriteRenderer.color = _interactColor;
        }
        else
            SpriteRenderer.color = _normalColor;
    }

    public abstract void Interact();
}
