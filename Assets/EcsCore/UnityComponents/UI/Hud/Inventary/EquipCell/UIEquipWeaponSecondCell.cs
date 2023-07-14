using System.Collections;
using UnityEngine;

public class UIEquipWeaponSecondCell : UIEquipCell
{
    protected override void OnButton()
    {
        if (conteiner == null)
        {
            if (dragCell.Conteiner != null)
            {
                if (dragCell.Conteiner is WeaponConteiner)
                {
                    SetConteiner(dragCell.Conteiner);
                    dragCell.Clear();
                }
            }
        }
        else
        {
            GetConteiner();
        }
    }
}