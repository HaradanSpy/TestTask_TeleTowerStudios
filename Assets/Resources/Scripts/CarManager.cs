using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    private int _materialId;
    public List<Material> materials = new List<Material>();
    public MeshRenderer bonnetRenderer;
    public Animator bonnetAnimator;
    public void ChangeMaterial() 
    {
        _materialId++;
        if (_materialId >= materials.Count) _materialId = 0;
        bonnetRenderer.material = materials[_materialId];
    }

    public void BonnetAction() 
    {
        bool b = !bonnetAnimator.GetBool("open");
        bonnetAnimator.SetBool("open", b);
    }
}
