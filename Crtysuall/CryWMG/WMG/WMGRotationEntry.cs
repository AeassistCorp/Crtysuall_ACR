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

public class WhiteMageRotationEntry : IRotationEntry
{
    public static JobViewWindow JobViewWindow;
    
    private readonly WhiteMageOverlay _lazyOverlay = new();
    public string OverlayTitle { get; } = "Crtysuall练级白魔";

    public void DrawOverlay()
    {
        
    }

    public string AuthorName { get; } = "Crtysuall";
    public Jobs TargetJob { get; } = Jobs.WhiteMage;
    public AcrType AcrType { get; } = AcrType.Normal;
    


    public List<ISlotResolver> SlotResolvers = new()
    {
        new 康复(),
        new 复活(),
        new 天赐祝福(),
        new 安慰之心(),
        new 狂喜之心(),
        new 天辉(),
        new 神速咏唱(),
        new 法令(),
        new 医济(),
        new 医治(),
        new 红花(),
        new 愈疗(),
        new 再生(),
        new 救疗(),
        new 治疗(),
        new 能力技相关(),
        new 神名(),
        new 水流幕(),
        new 神祝祷(),
        new 全大赦(),
        new 无中生有(),
        new 醒梦(),
        new 基础(),
    };

    public Rotation Build(string settingFolder)
    {
        WMGSettings.Build(settingFolder);
        return new Rotation(this, () => SlotResolvers)
            .SetRotationEventHandler(new WMGRotationEventHandler())
            .AddSettingUIs(new HealWMGSettingView())
            .AddSlotSequences();
        //.AddTriggerCondition(new TriggerCondCheckWMG())
        //.AddTriggerlineUpgradeFromData(Upgrade);
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
        jobViewWindow.AddQt("AOE", true);
        jobViewWindow.AddQt("DOT", true);
        jobViewWindow.AddQt("爆发", true);
        jobViewWindow.AddQt("停一下手", false);
        jobViewWindow.AddQt("GCD治疗", true);
        jobViewWindow.AddQt("能力技治疗", true);
        jobViewWindow.AddQt("红花", true);
        jobViewWindow.AddQt("群蓝花", true);
        jobViewWindow.AddQt("单蓝花", true);
        jobViewWindow.AddQt("再生", true);
        jobViewWindow.AddQt("拉人", true);
        
        jobViewWindow.AddHotkey("医济",new HotKeyResolver_NormalSpell(133,SpellTargetType.Self,false));
        jobViewWindow.AddHotkey("LB",new HotKeyResolver_NormalSpell(208,SpellTargetType.Self,false));
        jobViewWindow.AddHotkey("铃铛", new HotKeyResolver_NormalSpell(25862, SpellTargetType.Self, false));
        jobViewWindow.AddHotkey("庇护所", new HotKeyResolver_NormalSpell(3569, SpellTargetType.Self, false));
        jobViewWindow.AddHotkey("翅膀", new HotKeyResolver_NormalSpell(16536, SpellTargetType.Self, false));
        return true;
    }
}