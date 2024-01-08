using CombatRoutine;
using Common;
using Common.Define;
using CryWMG.WMG;

public class 狂喜之心 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.Gcd;
    public int Check()
    {
        if(Core.Me.ClassLevel <76) return -3;
        //检查是否打开蓝花开关
        if (!Qt.GetQt("群蓝花")) return -3;
        //检查CD
        if (!SpellsDefine.AfflatusRapture.IsReady()) return -3;
        //没蓝花不打
        if (Core.Get<IMemApiWhiteMage>().Lily() < 1) return -5;
        if (Core.Get<IMemApiWhiteMage>().Lily() == 3) return 1;
        //检查满足目标数量
        var skillTarget = PartyHelper.CastableAlliesWithin20.Count(r =>
            r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.AfflatusRapturePP);
        if (skillTarget >= WMGSettings.Instance.Curenum) return 0;
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(SpellsDefine.AfflatusRapture.GetSpell());
    }

 
}