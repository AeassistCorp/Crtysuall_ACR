using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;


namespace CryWMG.WMG.GCD;

public class 红花 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.Gcd;
    public int Check()
    {
        if(Core.Me.ClassLevel < 74) return -3;
        //检查CD
        if (!SpellsDefine.AfflatusMisery.IsReady()) return -3;
        //检查开关
        if (!Qt.GetQt("红花")) return -3;
        //检查量普
        if (Core.Get<IMemApiWhiteMage>().BloodLily() == 3) return 1;
        return -4;
    }

    public void Build(Slot slot)
    {
        slot.Add(SpellsDefine.AfflatusMisery.GetSpell());
    }


}