using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarUpdate : MonoBehaviour
{
    [SerializeField] GameObject hpBar;
    [SerializeField] PlayerCombat player;


    private void Update()
    {
        UpdateHP();
    }

    void UpdateHP()
    {
        hpBar.transform.localScale = new Vector3(player.currentHp / player.maxHp, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
    }
}
