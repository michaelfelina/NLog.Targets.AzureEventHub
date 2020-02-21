using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog.Targets.AzureEventHub
{
    [Target("AzureEventHub")]
    public partial class AzureEventHubTarget : TargetWithLayout
    {
        static EventHubClient _eventHubClient = null;

        public string PartitionKey { get; set; }
        [RequiredParameter]
        public string EventHubConnectionString { get; set; }

        [RequiredParameter]
        public string EventHubPath { get; set; }

        /// <summary>
        /// Takes the contents of the LogEvent and sends the message to EventHub
        /// </summary>
        /// <param name="logEvent"></param>
        /// 
        
        protected override void Write(LogEventInfo logEvent)
        {
            SendAsync(PartitionKey, logEvent);
        }

        private async Task<bool> SendAsync(string partitionKey, LogEventInfo logEvent)
        {
            try
            {             
                if (_eventHubClient == null)
                    _eventHubClient = EventHubClient.CreateFromConnectionString(EventHubConnectionString);
                var eventHubData = CreateEventData(logEvent);
                await _eventHubClient.SendAsync(eventHubData);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        private EventData CreateEventData(LogEventInfo data)
        {
            var logInformation = new LogEvent
            {
                SequenceID = data.SequenceID,
                TimeStamp = data.TimeStamp,
                Level = data.Level.ToString(),
                LoggerName = data.LoggerName,
                Message = data.FormattedMessage,
                Exception = data.Exception?.ToString(),
                CallerClassName = data.CallerClassName,
                CallerFilePath = data.CallerFilePath,
                CallerLineNumber = data.CallerLineNumber,
                CallerMemberName = data.CallerMemberName,
                FormatProvider = data.FormatProvider?.ToString(),
                FormattedMessage = data.FormattedMessage,
                HasProperties = data.HasProperties,
                HasStackTrace = data.HasStackTrace,
                MessageTemplateParameters = data.MessageTemplateParameters?.ToString(),
                Properties = data.Properties,
                StackTrace = data.StackTrace?.ToString(),
                UserStackFrame = data.UserStackFrame,
                UserStackFrameNumber = data.UserStackFrameNumber,                
            };

            var dataAsJson = JsonConvert.SerializeObject(logInformation);
            var eventHubData = new EventData(Encoding.UTF8.GetBytes(dataAsJson));
            return eventHubData;
        }
    } 
}
