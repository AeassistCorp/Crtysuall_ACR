using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;
using CryWMG.WMG;

public class 安慰之心 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.Gcd;
    public int Check()
    {
        //等级
        if(Core.Me.ClassLevel < 52) return -3;
        //检查是否打开单蓝花
        if (!Qt.GetQt("单蓝花")) return -3;
        //检查CD
        if (!SpellsDefine.AfflatusSolace.IsReady()) return -3;
        //没蓝花不打
        if (Core.Get<IMemApiWhiteMage>().Lily() < 1) return -5;
        //检查是否有满足条件的目标
        List<uint> Pbuff = new List<uint>
        {
            3255,
            AurasDefine.Holmgang,
            AurasDefine.Superbolide,
        };
        CharacterAgent skillTarget;
        if (WMGSettings.Instance.OnlyTank)
        {
            skillTarget = PartyHelper.CastableAlliesWithin30
                .Where(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.AfflatusSolacePP && r.IsTank() && !r.IsInvincible()&&!r.HasAura(AurasDefine.LivingDead)&&!r.HasAura(AurasDefine.WalkingDead)&&!r.HasAnyAura(Pbuff,3000))
                .OrderBy(r => r.CurrentHealthPercent)
                .FirstOrDefault();
        }
        else
        {
            skillTarget = PartyHelper.CastableAlliesWithin30
                .Where(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.AfflatusSolacePP && !r.IsInvincible()&&!r.HasAura(AurasDefine.LivingDead)&&!r.HasAura(AurasDefine.WalkingDead)&&!r.HasAnyAura(Pbuff,3000))
                .OrderBy(r => r.CurrentHealthPercent)
                .FirstOrDefault();
        }
        if (!skillTarget.IsValid) return -2;
        return 0;
    }

    public void Build(Slot slot)
    {
        List<uint> Pbuff = new List<uint>
        {
            3255,
            AurasDefine.Holmgang,
            AurasDefine.Superbolide,
        };
        CharacterAgent skillTarget;
        if (WMGSettings.Instance.OnlyTank)
        {
            skillTarget = PartyHelper.CastableAlliesWithin30
                .Where(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.AfflatusSolacePP && r.IsTank() && !r.IsInvincible()&&!r.HasAura(AurasDefine.LivingDead)&&!r.HasAura(AurasDefine.WalkingDead)&&!r.HasAnyAura(Pbuff,4000))
                .OrderBy(r => r.CurrentHealthPercent)
                .FirstOrDefault();
        }
        else
        {
            skillTarget = PartyHelper.CastableAlliesWithin30
                .Where(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.AfflatusSolacePP && !r.IsInvincible()&&!r.HasAura(AurasDefine.LivingDead)&&!r.HasAura(AurasDefine.WalkingDead)&&!r.HasAnyAura(Pbuff,4000))
                .OrderBy(r => r.CurrentHealthPercent)
                .FirstOrDefault();
           
        }
        slot.Add(new Spell(SpellsDefine.AfflatusSolace, skillTarget));
    }

   
   
}