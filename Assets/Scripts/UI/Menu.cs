using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    protected MenuManager menuManager { get; private set; }

    internal void Initialize(MenuManager menuManager)
    {
        this.menuManager = menuManager;
        OnInitialize();
    }

    internal void Show(object data)
    {
        OnBeforeShow(data);

        gameObject.SetActive(true);

        if (isPopup)
        {
            transform.SetAsLastSibling();
        }

        OnAfterShow();
    }

    internal void Hide()
    {
        OnBeforeHide();

        gameObject.SetActive(false);

        OnAfterHide();
    }

    protected virtual void OnInitialize()
    {

    }

    protected virtual void OnBeforeShow(object data)
    {

    }

    protected virtual void OnAfterShow()
    {

    }

    protected virtual void OnBeforeHide()
    {

    }

    protected virtual void OnAfterHide()
    {

    }
}
