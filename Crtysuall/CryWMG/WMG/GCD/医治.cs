using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;

namespace CryWMG.WMG.GCD;

public class 医治 : ISlotResolver
{

    public SlotMode SlotMode { get; } = SlotMode.Gcd;
    public int Check()
    {
       
        //检查开关
        if (!Qt.GetQt("GCD治疗")) return -3;
        if (Core.Me.ClassLevel >= 50) return -3;
        //检查CD
        if (!SpellsDefine.Medica.IsReady()) return -3;
        //检查满足目标人数
        var skillTarget = PartyHelper.CastableAlliesWithin20.Count(r =>
            r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.MedicalPP);
        if (skillTarget >= WMGSettings.Instance.Curenum) return 0;
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(SpellsDefine.Medica.GetSpell());
    }

  
}