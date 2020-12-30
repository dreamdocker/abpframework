using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Logging;

namespace FooModule.Exceptions
{
    public class MyException : Exception, IHasErrorCode, IHasErrorDetails, IHasLogLevel, IExceptionWithSelfLogging, IBusinessException, IUserFriendlyException
    {
        public string Code { get; set; }

        public string Details { get; set; }

        public IList<ValidationResult> ValidationErrors { get; set; }

        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        public void Log(ILogger logger)
        {
            logger.LogError("This is custom exceptionWith self logging !");
        }
    }
}
