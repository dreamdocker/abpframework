using FooModule.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace FooModule.Settings
{
    public class MySettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            var smtpHost = context.GetOrNull("Smtp.UserName");
            if (smtpHost != null)
            {
                smtpHost.DefaultValue = "admin@xcode.me";
                smtpHost.DisplayName = new LocalizableString(typeof(TestResource), "SmtpServer_DisplayName");
            }

            context.Add(new SettingDefinition("Example.Setting1", "www.xcode.me"));
            context.Add(new SettingDefinition("Example.Setting2"));
            context.Add(new SettingDefinition("Example.Setting3"));
        }
    }
}
