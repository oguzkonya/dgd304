using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Menu[] menus;
    private Menu currentMenu;
    private LinkedList<Menu> popups;

    public void Initialize()
    {
        menus = GetComponentsInChildren<Menu>(true);

        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].Initialize(this);
        }

        popups = new LinkedList<Menu>();
    }

    public void Show<T>(object data = null) where T : Menu
    {
        var requestedMenu = GetMenu<T>();

        if (requestedMenu == null)
        {
            return;
        }

        if (currentMenu == requestedMenu)
        {
            return;
        }

        if (currentMenu == null)
        {
            requestedMenu.Show(data);
        }
        else
        {
            if (requestedMenu.IsPopup)
            {
                requestedMenu.Show(data);
                Enqueue(requestedMenu);
            }
            else
            {
                currentMenu.Hide();
                requestedMenu.Show(data);
            }
        }

        if (!requestedMenu.IsPopup)
        {
            currentMenu = requestedMenu;
        }
    }

    public void Hide<T>() where T : Menu
    {
        var popupToHide = GetMenu<T>();

        if (popupToHide == null)
        {
            return;
        }

        if (!popupToHide.IsPopup)
        {
            return;
        }

        popupToHide.Hide();
        Dequeue(popupToHide);
    }

    // TODO: HideAllPopups

    private Menu GetMenu<T>() where T : Menu
    {
        return menus.FirstOrDefault(m => m.GetType() == typeof(T));
    }

    private void Enqueue(Menu menu)
    {
        Dequeue(menu);
        popups.AddLast(menu);
    }

    private void Dequeue(Menu menu)
    {
        if (popups.Contains(menu))
        {
            popups.Remove(menu);
        }
    }
}
