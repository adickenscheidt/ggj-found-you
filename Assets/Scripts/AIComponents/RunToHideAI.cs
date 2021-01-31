using UnityEngine;

public class RunToHideAI : BaseAIComponent
{
    public override string AiName => "RunToHide";
    public override FinishMode FinishMode => FinishMode.PointReached;
    public float hideObjectSightRange = 10f;

    private HideObject _targetHideObject;

    public override int GetAiValue(string currentAiName)
    {
        if (currentAiName != "Fleeing" && currentAiName != "RunToHide" || victim.nextHideTime > Time.time)
            return 0;

        return TryFindObjectToHide(hideObjectSightRange) ? 80 : 0;
    }

    public override void StartAi()
    {
        base.StartAi();
        WalkToPoint(_targetHideObject.transform.position);
    }

    public override void StopAi()
    {
        base.StopAi();
        _targetHideObject = null;
    }

    public override void Finish()
    {
        base.Finish();
        if (HideObjectInRange())
            HideInHideObject();
        _targetHideObject = null;
    }

    private bool TryFindObjectToHide(float hideRange)
    {
        if (_targetHideObject != null)
            return true;
        var hideObjects = new Collider[15];
        var size = Physics.OverlapSphereNonAlloc(GetParentTransform().position, hideRange, hideObjects);
        foreach (var currHideObject in hideObjects)
        {
            if (currHideObject == null)
                continue;
            var hideObject = TryGetHideObject(currHideObject.gameObject);
            if (hideObject != null)
            {
                _targetHideObject = hideObject;
                return true;
            }
        }

        return false;
    }

    private void HideInHideObject()
    {
        // GetParentTransform().GetChild(0).gameObject.SetActive(false);
        // gameObject.SetActive(false);
        // _targetHideObject.HideIn(GetParentTransform().gameObject);
        _targetHideObject.HideIn(victim);
    }

    private bool HideObjectInRange()
    {
        var hideRange = 0.7f;
        return (GetParentTransform().position - _targetHideObject.transform.position).magnitude < hideRange;
    }

    private HideObject TryGetHideObject(GameObject go)
    {
        var hideObject = go.GetComponent<HideObject>();
        if (hideObject != null)
            return hideObject;
        hideObject = go.GetComponentInParent<HideObject>();
        if (hideObject != null)
            return hideObject;
        hideObject = go.GetComponentInChildren<HideObject>();
        return hideObject;
    }
}
