using CombatRoutine;
using Common;
using Common.Define;

namespace CryWMG.WMG.GCD;

public class 基础 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.Gcd;
    public Spell GetSpell()
    {
        //检查开关
        if (Qt.GetQt("AOE"))
        {
            var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me, 8, 8);
            if (aoeCount >= 3 && Core.Me.ClassLevel > 45)
                //return SpellsDefine.Holy.GetSpell();
                return Core.Get<IMemApiSpell>().CheckActionChange(SpellsDefine.Holy.GetSpell().Id).GetSpell();
        }
        return Core.Get<IMemApiSpell>().CheckActionChange(SpellsDefine.Stone.GetSpell().Id).GetSpell();
    }

    

    public int Check()
    {
        if (PartyHelper.CastableParty.Count==8)
        {
            if (Core.Get<IMemApiBuff>().GetStack(PartyHelper.CastableParty[WMGSettings.Instance.Esuna-1],200)>=1)
            {
                return -1;
            }
        }

        if (Qt.GetQt("停一下手"))
        {
            return -1;
        }
        //检测是否可用
        if (Core.Get<IMemApiMove>().IsMoving()&& !Core.Me.HasAura(AurasDefine.Swiftcast)) return -1;
        return 0;
    }

    public void Build(Slot slot)
    {
        slot.Add(GetSpell());
    }
}