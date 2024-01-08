using System.Reflection;
using CombatRoutine;
using CombatRoutine.Opener;
using CombatRoutine.TriggerModel;
using CombatRoutine.View.JobView;
using Common.Define;
using Common.Language;
using CryWMG.WMG;
using CryWMG.WMG.Ability;
using CryWMG.WMG.GCD;
using CryWMG.WMG.时间轴;

namespace CryWMG;

public class 幻术师Entry : IRotationEntry
{
    public static JobViewWindow JobViewWindow;
    
    private readonly WhiteMageOverlay _lazyOverlay = new();
    public string OverlayTitle { get; } = "Crtysuall幻术师";
    public AcrType AcrType { get; } = AcrType.Normal;

    public void DrawOverlay()
    {
        
    }

    public string AuthorName { get; } = "Crtysuall";
    public Jobs TargetJob { get; } = Jobs.Conjurer;


    public List<ISlotResolver> SlotResolvers = new()
    {
        new 康复(),
        new 复活(),
        new 天辉(),
        new 医济(),
        new 医治(),
        new 救疗(),
        new 治疗(),
        new 基础(),
        new 能力技相关(),
        new 醒梦(),
    };

    public Rotation Build(string settingFolder)
    {
        WMGSettings.Build(settingFolder);
        return new Rotation(this, () => SlotResolvers)
            .SetRotationEventHandler(new WMGRotationEventHandler())
            .AddSettingUIs(new HealWMGSettingView())
            .AddSlotSequences()
            .AddTriggerCondition(new TriggerCondCheckWMG())
            .AddTriggerlineUpgradeFromData(Upgrade);
    }
    private void Upgrade(TriggerLine obj)
    {
        Check(obj.TriggerRoot);
    }

    void Check(TriggerNodeBase triggerNodeBase)
    {
        if (triggerNodeBase is TriggerActionNode triggerAction)
        {
            for (int i = 0; i < triggerAction.TriggerActions.Count; i++)
            {
                var act = triggerAction.TriggerActions[i];
            }
        }

        if (triggerNodeBase is TriggerCompBase triggerCompBase)
        {
            foreach (var v in triggerCompBase.Childs)
            {
                Check(v as TriggerNodeBase);
            }
        }
    }
 

  

    public void OnLanguageChanged(LanguageType languageType)
    {
    }
    public bool BuildQt(out JobViewWindow jobViewWindow)
    {
        jobViewWindow = new JobViewWindow(WMGSettings.Instance.JobViewSave, WMGSettings.Instance.Save, OverlayTitle);
        JobViewWindow = jobViewWindow; // 这里设置一个静态变量.方便其他地方用
        jobViewWindow.AddTab("通用", _lazyOverlay.DrawGeneral);
        jobViewWindow.AddTab("时间轴", _lazyOverlay.DrawTimeLine);
        jobViewWindow.AddTab("DEV", _lazyOverlay.DrawDev);
        jobViewWindow.AddQt("爆发药", true);
        jobViewWindow.AddQt("DOT", true);
        jobViewWindow.AddQt("爆发", true);
        jobViewWindow.AddQt("停一下手", false);
        jobViewWindow.AddQt("GCD治疗", true);
        jobViewWindow.AddQt("拉人", true);
        
        jobViewWindow.AddHotkey("医济",new HotKeyResolver_NormalSpell(133,SpellTargetType.Self,false));
        jobViewWindow.AddHotkey("LB",new HotKeyResolver_NormalSpell(208,SpellTargetType.Self,false));
        return true;
    }
}