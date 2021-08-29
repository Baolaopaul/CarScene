using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{
    
    [SerializeField] private Material breakLightsON;
    [SerializeField] private Material breakLightsOFF;
    [SerializeField] private Material HeadLightsON;
    [SerializeField] private Material HeadLightsOFF;
    [SerializeField] private Material backRideON;

    [SerializeField] private Renderer carCorpus;
    [SerializeField] private Material[] allMaterials;

    [SerializeField] private Light spotLightLeft;
    [SerializeField] private Light spotLightRight;

    private bool headLightsOn;
    
  
    void Start()
    {
        allMaterials = carCorpus.materials;
        headLightsOn = false;
    }

   
    void Update()
    {
        BreakLightsLogic();
        BackRideLightsLogic();
        HeadLightsLogic();
    }

    private void BreakLightsLogic()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift))
        {
            allMaterials[3] = breakLightsON;
            carCorpus.materials = allMaterials;
        }
        else
        {
            allMaterials[3] = breakLightsOFF;
            carCorpus.materials = allMaterials;
        }
    }

    private void BackRideLightsLogic()
    {
        if (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftShift))
            if (Input.GetKey(KeyCode.S))
            {
                allMaterials[3] = backRideON;
                carCorpus.materials = allMaterials;
            }
        else
        {
            allMaterials[3] = breakLightsOFF;
            carCorpus.materials = allMaterials;
        }
    }

    private void HeadLightsLogic()
    {
        if (!headLightsOn && Input.GetKeyDown(KeyCode.E))
        {
            allMaterials[2] = HeadLightsON;
            carCorpus.materials = allMaterials;
            spotLightLeft.intensity = 10f;
            spotLightRight.intensity = 10f;
            headLightsOn = true;
        }

        else if (headLightsOn && Input.GetKeyDown(KeyCode.E))
        {
            allMaterials[2] = HeadLightsOFF;
            carCorpus.materials = allMaterials;
            spotLightLeft.intensity = 0f;
            spotLightRight.intensity = 0f;
            headLightsOn = false;
        }
    }
}
