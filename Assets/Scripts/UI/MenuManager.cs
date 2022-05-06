using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Menu[] menus;
    private Menu currentMenu;
    // popup list

    public void Initialize()
    {
        menus = GetComponentsInChildren<Menu>(true);

        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].Initialize(this);
        }
    }

    public void Show<T>() where T : Menu
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
            requestedMenu.Show();
            currentMenu = requestedMenu;
        }
        else
        {
            // hide current menu
            // show requested menu
        }
    }

    private Menu GetMenu<T>() where T : Menu
    {
        return menus.FirstOrDefault(m => m.GetType() == typeof(T));
    }
}
