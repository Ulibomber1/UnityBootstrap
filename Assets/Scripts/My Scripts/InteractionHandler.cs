using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] protected string togglerName;
    [SerializeField] private List<Behaviour> ToggleableBehaviours;
    [SerializeField] private List<MeshRenderer> ToggleableMeshRenderers;
    [SerializeField] private List<Collider> ToggleableColliders;
    private MeshRenderer mr;
    private MeshCollider mc;
    [SerializeField]private bool isToggled = false;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        Interactable.OnInteractAction += OnInteractHandler;
        mr = gameObject.GetComponent<MeshRenderer>();
        mc = gameObject.GetComponent<MeshCollider>();

    }

    protected virtual void OnDestroy()
    {
        Interactable.OnInteractAction -= OnInteractHandler;
    }

    private void OnInteractHandler(string name, string parentName)
    {
        if (name != togglerName)
            return;
        isToggled = !isToggled;

        // Each of these must be done separately because of Unity's design choices around
        // some components not inheriting the Behaviour class
        foreach(Behaviour component in ToggleableBehaviours)
        {
            component.enabled = isToggled;
        }
        foreach(MeshRenderer mr in ToggleableMeshRenderers)
        {
            mr.enabled = isToggled;
        }
        foreach (Collider coll in ToggleableColliders)
        {
            coll.enabled = isToggled;
        }
    }
}
