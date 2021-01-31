using UnityEngine;

public class AIController : MonoBehaviour
{
    private BaseAIComponent[] _aiComponents;
    // private float _nextAiComponentCheck;

    [SerializeField]
    private BaseAIComponent _currentAI;

    // Start is called before the first frame update
    void Start()
    {
        _aiComponents = GetComponents<BaseAIComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentAI != null && _currentAI.currentState != AIState.Finished)
            return;
        var ai = GetActiveAI();
        StartAi(ai);
    }

    private void StartAi(BaseAIComponent ai)
    {
        _currentAI = ai;
        _currentAI.StartAi();
    }

    private BaseAIComponent GetActiveAI()
    {
        var aiValue = 0;
        BaseAIComponent newAi = null;
        foreach (var ai in _aiComponents)
        {
            var nextAiValue = ai.GetAiValue(_currentAI != null ? _currentAI.AiName : null);
            if (nextAiValue < aiValue)
                continue;
            aiValue = nextAiValue;
            newAi = ai;
        }

        return newAi;
    }
}
