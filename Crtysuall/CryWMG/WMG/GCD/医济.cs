using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;

namespace CryWMG.WMG.GCD;

public class 医济 : ISlotResolver
{

    public SlotMode SlotMode { get; } = SlotMode.Gcd;
    public int Check()
    {
        //检查等级
        if(Core.Me.ClassLevel < 50) return -3;
        //检查开关
        if (!Qt.GetQt("GCD治疗")) return -3;
        //检查CD
        if (!SpellsDefine.Medica2.IsReady()) return -3;
        //5s内避免重新放医技
        if (SpellsDefine.Medica2.RecentlyUsed(5000)) return -1;
        //自己身上有医技不放
        if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.Medica2, 3000)) return -1;
        //检查满足目标人数
        var skillTarget = PartyHelper.CastableAlliesWithin20.Count(r =>
            r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.MedicalIIPP);
        if (skillTarget >= WMGSettings.Instance.Curenum) return 0;
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(SpellsDefine.Medica2.GetSpell());
    }

  
}