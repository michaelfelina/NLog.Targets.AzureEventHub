using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NLog.Targets.AzureEventHub
{
    public class LogEvent
    {
        //
        // Summary:
        //     Gets the callsite class name
        public string CallerClassName { get; set; }
        //
        // Summary:
        //     Gets the callsite member function name
        public string CallerMemberName { get; set; }
        //
        // Summary:
        //     Gets the callsite source file path
        public string CallerFilePath { get; set; }
        //
        // Summary:
        //     Gets the callsite source file line number
        public int CallerLineNumber { get; set; }
        //
        // Summary:
        //     Gets or sets the exception information.        
        public string Exception { get; set; }
        //
        // Summary:
        //     Gets or sets the logger name.
        public string LoggerName { get; set; }

        //
        // Summary:
        //     Gets or sets the format provider that was provided while logging or null when
        //     no formatProvider was specified.
        public string FormatProvider { get; set; }
        //
        // Summary:
        //     Gets the entire stack trace.
        public string StackTrace { get; set; }
        //
        // Summary:
        //     Gets or sets the message formatter for generating NLog.LogEventInfo.FormattedMessage
        //     Uses string.Format(...) when nothing else has been configured.
        public string MessageFormatter { get; set; }
        //
        // Summary:
        //     Gets the formatted message.
        public string FormattedMessage { get; set; }
        //
        // Summary:
        //     Checks if any per-event properties (Without allocation)
        public bool HasProperties { get; set; }
        //
        // Summary:
        //     Gets the dictionary of per-event context properties.
        public IDictionary<object, object> Properties { get; set; }
        //
        // Summary:
        //     Gets or sets the log message including any parameter placeholders.
        public string Message { get; set; }
        //
        // Summary:
        //     Gets the number index of the stack frame that represents the user code (not the
        //     NLog code).
        public int UserStackFrameNumber { get; set; }
        //
        // Summary:
        //     Gets or sets the level of the logging event.
        public string Level { get; set; }
        //
        // Summary:
        //     Gets a value indicating whether stack trace has been set for this event.
        public bool HasStackTrace { get; set; }
        //
        // Summary:
        //     Gets the stack frame of the method that did the logging.
        public StackFrame UserStackFrame { get; set; }
        //
        // Summary:
        //     Gets the unique identifier of log event which is automatically generated and
        //     monotonously increasing.
        public int SequenceID { get; set; }

        //
        // Summary:
        //     Gets the named parameters extracted from parsing NLog.LogEventInfo.Message as
        //     MessageTemplate
        public string MessageTemplateParameters { get; set; }
        //
        // Summary:
        //     Gets or sets the timestamp of the logging event.
        public DateTime TimeStamp { get; set; }
    }
}
