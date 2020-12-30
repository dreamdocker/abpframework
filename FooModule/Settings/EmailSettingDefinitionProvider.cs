using Volo.Abp.Settings;

namespace FooModule.Settings
{
    public class EmailSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition("Smtp.Host", "127.0.0.1", isVisibleToClients: true),
                new SettingDefinition("Smtp.Port", "25"),
                new SettingDefinition("Smtp.UserName"),
                new SettingDefinition("Smtp.Password", isEncrypted: true),
                new SettingDefinition("Smtp.EnableSsl", "false")
            );
        }
    }
}
