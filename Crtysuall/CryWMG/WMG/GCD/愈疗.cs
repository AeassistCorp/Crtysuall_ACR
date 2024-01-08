using CombatRoutine;
using Common.Define;

namespace CryWMG.WMG.GCD;

public class 愈疗 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.Gcd;

    public int Check()
    {
        //检查开关
        if (!Qt.GetQt("GCD治疗")) return -3;
        //检查CD
        if (!SpellsDefine.Cure3.IsReady()) return -3;
        //检查满足条件人数
        var skillTarget = PartyHelper.CastableAlliesWithin10.Count(r =>
            r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.CureIIIPP);
        if (skillTarget >= WMGSettings.Instance.Curenum) return 0;
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(SpellsDefine.Cure3.GetSpell());
    }
}