using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Notch : XRSocketInteractor
{
    private Puller puller = null;
    private Arrow currArrow = null;

    protected override void Awake()
    {
        base.Awake();
        puller = GetComponent<Puller>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        puller.onSelectExit.AddListener(TryToReleaseArrow);

    }

    protected override void OnDisable()
    {
        base.OnDisable();
        puller.onSelectExit.RemoveListener(TryToReleaseArrow);
    }

    protected override void OnSelectEnter(XRBaseInteractable interactable)
    {
        base.OnSelectEnter(interactable);
        StoreArrow(interactable);
    }

    private void StoreArrow(XRBaseInteractable interactable)
    {
        if(interactable is Arrow arrow)
        {
            currArrow = arrow;
        }
    }

    private void TryToReleaseArrow(XRBaseInteractor interactor)
    {
        if (currArrow)
        {
            ForceDeselect();
            ReleaseArrow();
        }
    }

    private void ForceDeselect()
    {
        base.OnSelectExit(currArrow);
        currArrow.OnSelectExit(this);
    }

    private void ReleaseArrow()
    {
        currArrow.Release(puller.PullAmount);
        currArrow = null;
    }

    public override XRBaseInteractable.MovementType? selectedInteractableMovementTypeOverride
    {
        get { return XRBaseInteractable.MovementType.Instantaneous; }
    }
}
