using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.SettingManagement;

namespace FooModule.Settings
{
    public class SettingDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ISettingRepository _settingRepository;

        public SettingDataSeederContributor(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _settingRepository.GetCountAsync() <= 0)
            {
                await _settingRepository.InsertAsync(
                    new Setting(Guid.NewGuid(), "Smtp.Host", "192.168.0.1", "G"),
                    autoSave: true
                );

                await _settingRepository.InsertAsync(
                    new Setting(Guid.NewGuid(), "Smtp.Port", "443", "G"),
                    autoSave: true
                );

                await _settingRepository.InsertAsync(
                    new Setting(Guid.NewGuid(), "Smtp.EnableSsl", "true", "G"),
                    autoSave: true
                );
            }
        }
    }
}
