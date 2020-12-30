using System;
using Volo.Abp.Auditing;
using Volo.Abp.Data;

namespace FooModule.AuditLogging
{
    public class MyAuditLogContributor : AuditLogContributor
    {
        public override void PostContribute(AuditLogContributionContext context)
        {
            context.AuditInfo.SetProperty("MyCustomValue", Guid.NewGuid().ToString());

            base.PostContribute(context);
        }

        public override void PreContribute(AuditLogContributionContext context)
        {
            context.AuditInfo.Comments.Add("Some comment...");

            base.PreContribute(context);
        }
    }
}
