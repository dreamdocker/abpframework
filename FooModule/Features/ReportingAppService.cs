using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Features;

namespace FooModule.Features
{
    public class ReportingAppService : ApplicationService
    {
        private readonly IFeatureChecker _featureChecker;

        private readonly IFeatureManager _featureManager;

        public ReportingAppService(IFeatureChecker featureChecker, IFeatureManager featureManager)
        {
            _featureChecker = featureChecker;
            _featureManager = featureManager;
        }

        [RequiresFeature("MyApp.PdfReporting")]
        public async Task<object> GetAsync()
        {
            bool result = await _featureChecker.IsEnabledAsync("MyApp.PdfReporting");
            await _featureChecker.CheckEnabledAsync("MyApp.PdfReporting");
            string countLimit1 = await _featureChecker.GetOrNullAsync("MyApp.MaxProductCount");
            int countLimit2 = await _featureChecker.GetAsync<int>("MyApp.MaxProductCount");
            int countLimit3 = await _featureChecker.GetAsync("MyApp.MaxProductCount", 3);

            return new { result, countLimit1, countLimit2, countLimit3 };
        }

        public async Task UpdateAsync()
        {
            await _featureManager.SetForTenantAsync(Guid.NewGuid(), "MyApp.PdfReporting", true.ToString());
            await _featureManager.SetForUserAsync(Guid.NewGuid(), "MyApp.PdfReporting", true.ToString());
        }
    }
}
