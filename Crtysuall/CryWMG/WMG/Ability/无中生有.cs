using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;
namespace CryWMG.WMG.Ability;

public class 无中生有 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.OffGcd;

    public int Check()
    {
        //等级
        if(Core.Me.ClassLevel < 58) return -3;
        //检查CD
        if (!SpellsDefine.ThinAir.IsReady()) return -1;
        //快溢出了扔一个
        if (SpellsDefine.ThinAir.IsMaxChargeReady(0.05f))
            return 1;
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(SpellsDefine.ThinAir.GetSpell());
    }
}