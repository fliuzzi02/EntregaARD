using System.Collections;
using UnityEngine;
using UnityEngine.XR.Management;

public class VRMode : MonoBehaviour
{
    private bool isVRActive = false;

    void Start()
    {
        // Initialize VR mode
        StartCoroutine(DisableVR());
    }

    void Update()
    {
        // Check if the 'V' key is pressed
        if (Input.GetKeyDown(KeyCode.V))
        {
            ToggleVR();
        }
    }

    private void ToggleVR()
    {
        if (isVRActive)
        {
            // Exit VR mode
            StartCoroutine(DisableVR());
        }
        else
        {
            // Enter VR mode
            StartCoroutine(EnableVR());
        }
    }

    private IEnumerator EnableVR()
    {
        XRGeneralSettings.Instance.Manager.InitializeLoaderSync();
        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            isVRActive = true;
        }
        else
        {
            Debug.LogError("Failed to start VR subsystems.");
        }
        yield return null;
    }

    private IEnumerator DisableVR()
    {
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        isVRActive = false;
        yield return null;
    }
}
