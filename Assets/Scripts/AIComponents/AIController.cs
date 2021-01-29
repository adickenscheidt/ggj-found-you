using UnityEngine;

public class AIController : MonoBehaviour
{
    private BaseAIComponent[] _aiComponents;
    private float _nextAiComponentCheck;

    private BaseAIComponent _currentAI;

    // Start is called before the first frame update
    void Start()
    {
        _aiComponents = GetComponents<BaseAIComponent>();
        _nextAiComponentCheck = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < _nextAiComponentCheck)
            return;

        var ai = GetActiveAI();
        StartAi(ai);
    }

    private void StartAi(BaseAIComponent ai)
    {
        _nextAiComponentCheck = Time.time + ai.GetExecutionTime();
        if (ai == _currentAI)
            return;
        _currentAI?.StopAi();
        _currentAI = ai;
        _currentAI.StartAi();
    }

    private BaseAIComponent GetActiveAI()
    {
        var aiValue = 0;
        BaseAIComponent newAi = null;
        foreach (var ai in _aiComponents)
        {
            var nextAiValue = ai.GetAiValue(_currentAI?.AiName);
            if (nextAiValue < aiValue)
                continue;
            aiValue = nextAiValue;
            newAi = ai;
        }

        return newAi;
    }
}
