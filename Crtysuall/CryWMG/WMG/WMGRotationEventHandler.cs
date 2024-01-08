#region

using CombatRoutine;
using Common;
using Common.Define;

#endregion

namespace CryWMG.WMG;

public class WMGRotationEventHandler : IRotationEventHandler
{
    public void OnResetBattle()
    {
        WMGBattleData.Instance.Reset();
        Qt.Reset();
    }

    public Task OnNoTarget()
    {
        if (AI.Instance.BattleData.HighPrioritySlots_GCD.Count > 0)
        {
            if (AI.Instance.BattleData.HighPrioritySlots_GCD.Peek().CastTime.TotalSeconds > 0)
                if (Core.Get<IMemApiMove>().IsMoving())
                    return Task.CompletedTask;

            if (AI.Instance.BattleData.HighPrioritySlots_GCD.Peek().Id == 16534 ||
                AI.Instance.BattleData.HighPrioritySlots_GCD.Peek().Id == 16531)
                if (Core.Get<IMemApiWhiteMage>().Lily() < 1)
                    return Task.CompletedTask;
            if (AI.Instance.BattleData.HighPrioritySlots_GCD.Peek().Id == 16535)
                if (Core.Get<IMemApiWhiteMage>().BloodLily() != 3)
                    return Task.CompletedTask;
            if (AI.Instance.BattleData.NextSlot != null)
                AI.Instance.BattleData.NextSlot.Add(AI.Instance.BattleData.HighPrioritySlots_GCD.Peek());
            else
                AI.Instance.BattleData.NextSlot = new Slot().Add(AI.Instance.BattleData.HighPrioritySlots_GCD.Peek());
        }

        if (AI.Instance.BattleData.HighPrioritySlots_OffGCD.Count > 0)
            if (AI.Instance.BattleData.HighPrioritySlots_OffGCD.Peek().Charges >= 1)
            {
                if (AI.Instance.BattleData.NextSlot != null)
                    AI.Instance.BattleData.NextSlot.Add(AI.Instance.BattleData.HighPrioritySlots_OffGCD.Peek());
                else
                    AI.Instance.BattleData.NextSlot =
                        new Slot().Add(AI.Instance.BattleData.HighPrioritySlots_OffGCD.Peek());
            }

        return Task.CompletedTask;
    }

    public void AfterSpell(Slot slot, Spell spell)
    {
        switch (spell.Id)
        {
        }

        if (AI.Instance.BattleData.HighPrioritySlots_OffGCD.Count > 0)
            if (spell == AI.Instance.BattleData.HighPrioritySlots_OffGCD.Peek())
                AI.Instance.BattleData.HighPrioritySlots_OffGCD.Dequeue();
        if (AI.Instance.BattleData.HighPrioritySlots_GCD.Count > 0)
            if (spell == AI.Instance.BattleData.HighPrioritySlots_GCD.Peek())
                AI.Instance.BattleData.HighPrioritySlots_GCD.Dequeue();
        switch (spell.Id)
        {
            case SpellsDefine.GlareIii:
            case SpellsDefine.PresenceofMind:
                AI.Instance.BattleData.LimitAbility = true;
                break;
            case SpellsDefine.AfflatusMisery:
            case SpellsDefine.AfflatusRapture:
            case SpellsDefine.AfflatusSolace:
            case SpellsDefine.Dia:
                AI.Instance.BattleData.LimitAbility = false;
                break;
        }
    }

    public void OnBattleUpdate(int currTime)
    {
    }

    public Task OnPreCombat()
    {
        return Task.CompletedTask;
    }
}