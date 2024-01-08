using CombatRoutine.TriggerModel;
using Common;
using Common.GUI;
using Common.Language;

namespace CryWMG.WMG.时间轴
{
    public class TriggerCondCheckWMG : ITriggerCond
    {
        [LabelName(DisplayName = "蓝花数量")]
        public int Lily { get; set; }

        public string DisplayName => "WHM/检测量普".Loc();
        public string Remark { get; set; }
        public void Check()
        {
        }



        public bool Draw()
        {
            return false;
        }

        public bool Handle(ITriggerCondParams triggerCondParams)
        {
            if (Core.Get<IMemApiWhiteMage>().Lily()>=Lily)
            {
                return true;
            }
            return false;
        }
    }
}