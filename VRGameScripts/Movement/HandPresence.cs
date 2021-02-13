using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController = false;

    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;
    public List<GameObject> controllerPrefabs;

    private InputDevice targetDevice;
    private GameObject spawnHandModel;
    private GameObject spawnControllerModels;
    private Animator handAnimator;

    void Start()
    {
        TryInitialize();
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawnControllerModels = Instantiate(prefab, transform);
            }
            else
            {
                Debug.Log("Couldn't find matching controller prefab");
                spawnControllerModels = Instantiate(controllerPrefabs[0], transform);
            }

            spawnHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnHandModel.GetComponent<Animator>();
        }
    }

    void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            if (showController)
            {
                spawnHandModel.SetActive(false);
                spawnControllerModels.SetActive(true);
            }
            else
            {
                spawnHandModel.SetActive(true);
                spawnControllerModels.SetActive(false);
                UpdateHandAnimation();
            }
        }        
    }
}
