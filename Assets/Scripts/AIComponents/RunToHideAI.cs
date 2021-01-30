using UnityEngine;

public class RunToHideAI : BaseAIComponent
{
    public override string AiName => "RunToHide";
    public float hideObjectSightRange = 10f;

    private HideObject _targetHideObject;

    public override int GetAiValue(string currentAiName)
    {
        if (currentAiName != "Fleeing" && currentAiName != "RunToHide")
            return 0;

        return TryFindObjectToHide(hideObjectSightRange) ? 80 : 0;
    }

    public override void StopAi()
    {
        base.StopAi();
        _targetHideObject = null;
    }

    public override void AIUpdate()
    {
        if (HideObjectInRange())
            HideInHideObject();
        else
            RunTowardsHideObject();
    }

    private bool TryFindObjectToHide(float hideRange)
    {
        if (_targetHideObject != null)
            return true;
        var hideObjects = new Collider[5];
        var size = Physics.OverlapSphereNonAlloc(GetParentTransform().position, hideRange, hideObjects);
        foreach (var currHideObject in hideObjects)
        {
            var hideObject = currHideObject?.GetComponent<HideObject>();
            if (hideObject != null)
            {
                _targetHideObject = hideObject;
                return true;
            }
        }

        return false;
    }

    private void RunTowardsHideObject()
    {
        var transformPosition = _targetHideObject.transform.position - GetParentTransform().position;
        transformPosition.y = 0;
        GetParentTransform().Translate(transformPosition.normalized * (Time.fixedDeltaTime * victim.movementSpeed),
            Space.World);
    }

    private void HideInHideObject()
    {
        GetParentTransform().GetChild(0).gameObject.SetActive(false);
        gameObject.SetActive(false);
        _targetHideObject.HideIn(GetParentTransform().gameObject);
    }

    private bool HideObjectInRange()
    {
        var hideRange = 0.2f;
        return (GetParentTransform().position - _targetHideObject.transform.position).magnitude < hideRange;
    }
}
