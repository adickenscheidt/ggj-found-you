using System.Collections.Generic;
using UnityEngine;

public class PanicAI : BaseAIComponent
{
    public override string AiName => "Panic";
    [SerializeField] private List<Vector3> _walkingPoints = new List<Vector3>();
    [SerializeField] private Vector3 _currentWalkingPoint;
    private int _currentWalkingPointIndex;

    public override int GetAiValue(string currentAiName)
    {
        return IsPlayerInRange(15f) ? 80 : 0;
    }

    public override float GetExecutionTime()
    {
        return 10f;
    }

    public override void StartAi()
    {
        base.StartAi();
        _walkingPoints.Add(GetParentTransform().position - (Vector3.left * 2));
        _walkingPoints.Add(GetParentTransform().position - (Vector3.back * 2));
        _walkingPoints.Add(GetParentTransform().position - (Vector3.right * 2));
        _walkingPoints.Add(GetParentTransform().position - (Vector3.forward * 2));
        _currentWalkingPoint = _walkingPoints[0];
        _currentWalkingPointIndex = 0;
    }

    public override void StopAi()
    {
        base.StopAi();
        _walkingPoints.Clear();
    }

    public override void AIUpdate()
    {
        if (ReachedCurrentWalkingPoint())
            NextWalkingPoint();
        RunToCurrentPoint();
    }

    private void RunToCurrentPoint()
    {
        // Vector3.MoveTowards(GetParentTransform().position, _currentWalkingPoint, victim.movementSpeed * Time.deltaTime);
        GetParentTransform()
            .Translate(
                (_currentWalkingPoint - GetParentTransform().position).normalized * victim.movementSpeed *
                Time.deltaTime, Space.World);
    }

    private void NextWalkingPoint()
    {
        _currentWalkingPointIndex = (_currentWalkingPointIndex + 1) % _walkingPoints.Count;
        _currentWalkingPoint = _walkingPoints[_currentWalkingPointIndex];
    }

    private bool ReachedCurrentWalkingPoint()
    {
        return Vector3.Distance(_currentWalkingPoint, GetParentTransform().position) < 0.2f;
    }
}
