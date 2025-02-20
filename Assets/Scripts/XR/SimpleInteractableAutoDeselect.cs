using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// This is a script that is used to automatically deselect a simple interactable when it is selected.
/// Otherwise, when selecting a simple interactable (like a button), the player would need to deselect it before selecting another object.
/// </summary>
public class SimpleInteractableAutoDeselect : MonoBehaviour
{
    public float selectionCooldown = 0.5f;

    private void Start()
    {
        XRBaseInteractor baseInteractor = GetComponent<XRBaseInteractor>();
        baseInteractor.selectEntered.AddListener(AutoExitSelect);
    }

    public void AutoExitSelect(SelectEnterEventArgs args)
    {
        Debug.Log("Selected object " + args.interactableObject.transform.name);
        StartCoroutine(DeselectAfterCooldown(args));
    }

    public IEnumerator DeselectAfterCooldown(SelectEnterEventArgs args)
    {
        ///Use a coroutine since deselecting a simple interactable immediately after selecting it may cause the player to select an unwanted object.
        bool selectedObjectIsSimple = args.interactableObject.transform.GetComponent<XRSimpleInteractable>();

        if (selectedObjectIsSimple)
        {
            yield return new WaitForSeconds(selectionCooldown);
            XRInteractionManager interactionManager = args.manager;

            if (args.interactableObject.isSelected)
            {
                interactionManager.SelectExit(args.interactorObject, args.interactableObject);
            }
        }
    }
}
