using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuContext
{
    Initalize,
    BeforeShow,
    Show,
    AfterShow,
    BeforeHide,
    Hide,
    AfterHide
}

public abstract class Menu : MonoBehaviour
{
    [SerializeField]
    private bool isPopup;
    public bool IsPopup
    {
        get
        {
            return isPopup;
        }
    }

    public event Action<MenuContext> MenuHandle;

    internal void Show()
    {
        OnBeforeShow();
        MenuHandle?.Invoke(MenuContext.BeforeShow);

        //gameObject.SetActive(true); The object itself is always enabled due to we need to subscribe it on awake.
        MenuHandle?.Invoke(MenuContext.Show);

        if (isPopup)
        {
            transform.SetAsLastSibling();
        }

        OnAfterShow();
        MenuHandle?.Invoke(MenuContext.AfterShow);
    }

    internal void Hide()
    {
        OnBeforeHide();
        MenuHandle?.Invoke(MenuContext.BeforeHide);

        //gameObject.SetActive(false);
        MenuHandle?.Invoke(MenuContext.Hide);

        OnAfterHide();
        MenuHandle?.Invoke(MenuContext.AfterHide);
    }

    protected virtual void Awake()
    {
        OnInitialize();
    }

    protected virtual void OnInitialize()
    {

    }

    protected virtual void OnBeforeShow()
    {
        foreach(var transform in GetComponentsInChildren<Transform>(true)) 
        {
            transform.gameObject.SetActive(true);
        }
    }

    protected virtual void OnAfterShow()
    {

    }

    protected virtual void OnBeforeHide()
    {
        foreach (var transform in GetComponentsInChildren<Transform>(true))
        {
            transform.gameObject.SetActive(false);
        }
    }

    protected virtual void OnAfterHide()
    {

    }
}
