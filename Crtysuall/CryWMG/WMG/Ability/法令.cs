using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;

namespace CryWMG.WMG.Ability;

public class 法令 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.OffGcd;

    public int Check()
    {
        //等级
        if(Core.Me.ClassLevel < 56) return -3;
        //检查CD
        if (!SpellsDefine.Assize.IsReady())
            return -1;
        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(SpellsDefine.Assize.GetSpell());
    }
}