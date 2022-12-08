using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Scr_TeleportationController : MonoBehaviour
{
    [SerializeField] TeleportationProvider provider;
    [SerializeField] XRRayInteractor interactor;
    void Start()
    {
        interactor.enabled = false;
    }
    public void OnTeleportModeActivate(InputAction.CallbackContext context)
    {
        Debug.Log("HAH");
        interactor.enabled = true;
    }

    public void OnTeleportModeCancel(InputAction.CallbackContext context)
    {
        if (interactor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            TeleportRequest request = new TeleportRequest();
            request.destinationPosition = hit.point;
            provider.QueueTeleportRequest(request);
        }
        interactor.enabled = false;
    }
}
