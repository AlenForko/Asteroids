using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Codice.Client.BaseCommands.Import;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(ShipInfo))]
public class ShipEditor : Editor
{
    [SerializeField] private VisualTreeAsset shipInfo;

    public override VisualElement CreateInspectorGUI()
    {
        // Create a new VisualElement to be the root of our inspector UI
        VisualElement myInspector = new VisualElement();

        // Load from default reference
        shipInfo.CloneTree(myInspector);

        //ThrottleSettings
        var throttleSlider = myInspector.Q<Slider>("ThrottleSlider");
        throttleSlider.RegisterCallback<ChangeEvent<float>>(evt =>
        {
            throttleSlider.value = evt.newValue;
        });
        
        //RotationSettings
        var rotationSlider = myInspector.Q<Slider>("RotationSlider");
        rotationSlider.RegisterCallback<ChangeEvent<float>>(evt =>
        {
            rotationSlider.value = evt.newValue;
        });
        
        //HealthSettings
        var healthSlider = myInspector.Q<SliderInt>("HealthSlider");
        healthSlider.RegisterCallback<ChangeEvent<int>>(evt =>
        {
            healthSlider.value = evt.newValue;
        });

        // Return the finished inspector UI
        return myInspector;
    }
}


