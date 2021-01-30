using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool _isInteractable;
    private Color _normalColor;
    private Color _interactColor = new Color(0.7f, 0, 0);
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
            Debug.LogError($"No SpriteRenderer found on {this.name}!");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void HightlightAsInteractable(bool highlight)
    {
        if (_spriteRenderer == null)
            return;
        if (_isInteractable == highlight)
            return;

        _isInteractable = highlight;
        if (_isInteractable)
        {
            _normalColor = _spriteRenderer.color;
            _spriteRenderer.color = _interactColor;
        }
        else
            _spriteRenderer.color = _normalColor;
    }

    public void Interact()
    {
        // TODO: Interact
        Debug.Log("Interact with me senpai!");
    }
}
