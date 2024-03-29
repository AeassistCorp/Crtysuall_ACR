﻿using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;
public class 醒梦 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.OffGcd;

    public int Check()
    {   //冷却没好不用
        if (!SpellsDefine.LucidDreaming.IsReady())
            return -1;
        //LogHelper.Info("MANA"+Core.Me.CurrentMana);

        //蓝量大于8000不用
        if (Core.Me.CurrentMana > 8000) return -2;
        return 0;
    }

    public void Build(Slot slot)
    {   //狂用醒梦
        slot.Add(SpellsDefine.LucidDreaming.GetSpell());
    }
}