using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;

namespace CryWMG.WMG.Ability;

public class 水流幕 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.OffGcd;

    public int Check()
    {
        //等级
        if(Core.Me.ClassLevel < 86) return -3;
        //检查水流幕CD
        if (!SpellsDefine.Aquaveil.IsReady()) return -1;
        //检查开关
        if (!Qt.GetQt("能力技治疗")) return -3;
        //检查BOSS是否读条死刑类技能
        if (DeathSentenceHelper.IsDeathSentence(Core.Me.GetCurrTarget())) return 1;
        //检查是否有满足条件的目标
        CharacterAgent skillTarget;
        if (WMGSettings.Instance.OnlyTank)
        {
            skillTarget = PartyHelper.CastableAlliesWithin30.FirstOrDefault(r =>
                r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.AquaveilPP && r.IsTank());
        }
        else
        {
            skillTarget = PartyHelper.CastableAlliesWithin30.FirstOrDefault(r =>
                r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.AquaveilPP && r.IsTank());
        }
        if (!skillTarget.IsValid) return -2;
        //水流幕不提供奶量所以默认关闭
        return -1;
    }


    public void Build(Slot slot)
    {
        var skillTarget = Core.Me.GetCurrTargetsTarget();
        slot.Add(new Spell(SpellsDefine.Aquaveil, skillTarget));
    }
}