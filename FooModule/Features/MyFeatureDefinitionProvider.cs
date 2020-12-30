using FooModule.Localization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace FooModule.Features
{
    public class MyFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        //public override void Define(IFeatureDefinitionContext context)
        //{
        //    var myGroup = context.AddGroup("MyApp");

        //    myGroup.AddFeature("MyApp.PdfReporting", defaultValue: "true", isVisibleToClients: false);
        //    myGroup.AddFeature("MyApp.MaxProductCount", defaultValue: "10");
        //}

        public override void Define(IFeatureDefinitionContext context)
        {
            var myGroup = context.AddGroup("MyApp");

            myGroup.AddFeature(
                "MyApp.PdfReporting",
                defaultValue: "false",
                displayName: LocalizableString.Create<TestResource>("PdfReporting"),
                valueType: new ToggleStringValueType()
            );

            myGroup.AddFeature(
                "MyApp.MaxProductCount",
                defaultValue: "10",
                displayName: LocalizableString.Create<TestResource>("MaxProductCount"),
                valueType: new FreeTextStringValueType(new NumericValueValidator(0, 100))
            );
        }

        //public override void Define(IFeatureDefinitionContext context)
        //{
        //    var myGroup = context.AddGroup("MyApp");

        //    var reportingFeature = myGroup.AddFeature(
        //        "MyApp.Reporting",
        //        defaultValue: "false",
        //        displayName: LocalizableString.Create<TestResource>("Reporting"),
        //        valueType: new ToggleStringValueType()
        //    );

        //    reportingFeature.CreateChild(
        //        "MyApp.PdfReporting",
        //        defaultValue: "false",
        //        displayName: LocalizableString.Create<TestResource>("PdfReporting"),
        //        valueType: new ToggleStringValueType()
        //    );

        //    reportingFeature.CreateChild(
        //        "MyApp.ExcelReporting",
        //        defaultValue: "false",
        //        displayName: LocalizableString.Create<TestResource>("ExcelReporting"),
        //        valueType: new ToggleStringValueType()
        //    );
        //}
    }
}