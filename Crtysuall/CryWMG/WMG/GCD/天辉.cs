using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;

namespace CryWMG.WMG.GCD;

public class 天辉 : ISlotResolver
{
    public Spell GetSpell()
    {
        return Core.Get<IMemApiSpell>().CheckActionChange(SpellsDefine.Aero.GetSpell().Id).GetSpell();
    }

    public SlotMode SlotMode { get; } = SlotMode.Gcd;

    public int Check()
    {
        if (Qt.GetQt("停一下手"))
        {
            return -1;
        }
        //检测是否将要过期
        if (Core.Me.GetCurrTarget().HasMyAuraWithTimeleft(AurasDefine.Aero, 3000) ||
            Core.Me.GetCurrTarget().HasMyAuraWithTimeleft(AurasDefine.Aero2, 3000) ||
            Core.Me.GetCurrTarget().HasMyAuraWithTimeleft(AurasDefine.Dia, 3000))
            return -1;
        //检测是否在黑名单中
        if (DotBlacklistHelper.IsBlackList(Core.Me.GetCurrTarget()))
            return -10;
        if (Core.Me.GetCurrTarget().CurrentHealthPercent < WMGSettings.Instance.dotpercent)
            return -1;
        //检查开关
        if (!Qt.GetQt("DOT")) return -3;
        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(GetSpell());
    }
}