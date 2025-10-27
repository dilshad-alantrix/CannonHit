using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BreakType
{
    wood,
    wall
}

public class Breakble : MonoBehaviour
{
    [SerializeField] private GameObject orgObject;
    [SerializeField] private GameObject brokObject;
    [SerializeField] private BreakType breakType;

    private Animator _animator;

    private BoxCollider collider;

    void Awake()
    {
        orgObject.SetActive(true);
        brokObject.SetActive(false);
        collider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();
    }



    public void Break()
    {
        orgObject.SetActive(false);
        brokObject.SetActive(true);
        Invoke("onDesableColider", 0.5f);
        if (breakType == BreakType.wall)
        {
            AudioManager.instance.PlaySfx(AudioManager.instance.wallBreakClip);
        }
        else
        {
            AudioManager.instance.PlaySfx(AudioManager.instance.woodBreakClip);
        }

        if(_animator != null)
        {
            _animator.enabled = false;
        }
    }

    private void onDesableColider()
    {
        collider.enabled = false;
    }

    private void destroy()
    {
        Destroy(gameObject);
    }



}
