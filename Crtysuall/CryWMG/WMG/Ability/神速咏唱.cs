using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;

namespace CryWMG.WMG.Ability;

public class 神速咏唱 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.OffGcd;

    public int Check()
    {
        //等级
        if(Core.Me.ClassLevel < 30) return -3;
        //检查开关
        if (!Qt.GetQt("爆发")) return -3;
        //检查CD
        if (!SpellsDefine.PresenceofMind.IsReady())
            return -1;
        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(SpellsDefine.PresenceofMind.GetSpell());
    }
}