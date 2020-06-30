using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.RequestModels
{
    public class LogRequest
    {
        #region Constants

        /// <summary>
        /// Use this keyword whenever timing a call outside application.
        /// </summary>
        public const string KeywordCall = "remoteCall";

        /// <summary>
        /// Add this keyword whenever a timed call fail.
        /// </summary>
        public const string KeywordCallFail = "remoteCallFail";

        /// <summary>
        /// Use this keyword when timing calls to external systems. Also add keyword <see cref="KeywordCall"/>.
        /// </summary>
        public const string KeywordExternalCall = "extCall";

        /// <summary>
        /// Use this keyword when timing calls to internal systems.
        /// </summary>
        public const string KeywordInternalCall = "intCall";

        /// <summary>
        /// Use this for <see cref="Timing1Name"/> when using <see cref="KeywordCall"/>.
        /// </summary>
        public const string Timing1NameCallElapsed = "elapsed";


        #endregion

        public string Description { get; set; }
        public string Header { get; set; }

        /// <summary>
        /// The point in time the log was initially created in (iso8601 format)
        /// </summary>
        public string LogDate { get; set; }
        /// <summary>
        /// Provides an hint on the host operating system issuing the log.
        /// </summary>
        public string HostOs { get; set; }
        /// <summary>
        /// Provides a hint on the host operating system version issuing the log.
        /// </summary>
        public string HostOsVersion { get; set; }
        /// <summary>
        /// Provides a unique hint on the installation on the device.
        /// This is not an id of the device, but an id of actual installation of the app on a device.
        /// </summary>
        public string AppInstallationId { get; set; }
        public string AppName { get; set; }
        /// <summary>
        /// A string that identifies the app issuing the log. 
        /// </summary>
        public string AppService { get; set; }
        /// <summary>
        /// A string that identifies the version of the app issuing the log.
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// Provides an identification of the module / component / layer / sub-part of the app issuing the log. 
        /// </summary>
        public string AppComponent { get; set; }

        /// <summary>
        /// An optional space delimited list of exceptions. 
        /// </summary>
        private string Exceptions { get; set; }

        /// <summary>
        /// An optional detailed exception description, possibly including a stack trace, that provides plenty of info for debugging  and problem resolving.
        /// </summary>
        private string ExceptionDetails { get; set; }

        /// <summary>
        /// Keywords are used to subdivide and / or group information under an application, enabling Kibana to precisely target specific information.
        /// Note: When timing calls externally or internally, you should use <see cref="KeywordCall"/>.
        /// In addition, use <see cref="KeywordExternalCall"/> or <see cref="KeywordInternalCall"/> as appropriate.
        /// </summary>
        public List<string> Keywords { get; set; }

        /// <summary>
        /// Provides timing for a particular information in an aggregatable format.
        /// </summary>
        public TimeSpan? Timing1 { get; set; }

        /// <summary>
        /// Provides a (short) name, helping the log viewer staff interpreting the figure.
        /// NOTE: By convention, when using <see cref="KeywordCall"/>,
        ///  <see cref="Timing1Name"/> must be set to <see cref="Timing1NameCallElapsed"/>, and <see cref="Timing1"/> must be the timespan for the call.
        /// </summary>
        public string Timing1Name { get; set; }

        /// <summary>
        /// Provides timing for a particular information in an aggregatable format.
        /// </summary>
        public TimeSpan? Timing2 { get; set; }

        /// <summary>
        /// Provides a (short) name, helping the log viewer staff interpreting the figure
        /// </summary>
        public string Timing2Name { get; set; }

        /// <summary>
        /// Provides timing for a particular information in an aggregatable format.
        /// </summary>
        public TimeSpan? Timing3 { get; set; }

        /// <summary>
        /// Provides a (short) name, helping the log viewer staff interpreting the figure
        /// </summary>
        public string Timing3Name { get; set; }

        /// <summary>
        /// Provides timing for a particular information in an aggregatable format.
        /// </summary>
        public TimeSpan? Timing4 { get; set; }

        /// <summary>
        /// Provides a (short) name, helping the log viewer staff interpreting the figure
        /// </summary>
        public string Timing4Name { get; set; }

        /// <summary>
        /// Provides count for a particular information in an aggregatable format.
        /// </summary>
        public long? Count1 { get; set; }

        /// <summary>
        /// Provides a (short) name, helping the log viewer staff interpreting the figure
        /// </summary>
        public string Count1Name { get; set; }

        /// <summary>
        /// Provides count for a particular information in an aggregatable format.
        /// </summary>
        public long? Count2 { get; set; }

        /// <summary>
        /// Provides a (short) name, helping the log viewer staff interpreting the figure
        /// </summary>
        public string Count2Name { get; set; }

        /// <summary>
        /// Provides count for a particular information in an aggregatable format.
        /// </summary>
        public long? Count3 { get; set; }

        /// <summary>
        /// Provides a (short) name, helping the log viewer staff interpreting the figure
        /// </summary>
        public string Count3Name { get; set; }

        /// <summary>
        /// Provides count for a particular information in an aggregatable format.
        /// </summary>
        public long? Count4 { get; set; }

        /// <summary>
        /// Provides a (short) name, helping the log viewer staff interpreting the figure
        /// </summary>
        public string Count4Name { get; set; }

        /// <summary>
        /// Provides a (short) name, helping the log viewer staff interpreting the figure
        /// </summary>
        public string Key1Name { get; set; }

        /// <summary>
        /// Provides a key that can be used for grouping log results (as opposed to keywords that are used for filtering. 
        /// </summary>
        public string Key1Value { get; set; }

        /// <summary>
        /// Provides a (short) name, helping the log viewer staff interpreting the figure
        /// </summary>
        public string Key2Name { get; set; }

        /// <summary>
        /// Provides a key that can be used for grouping log results (as opposed to keywords that are used for filtering. 
        /// </summary>
        public string Key2Value { get; set; }

        /// <summary>
        /// Provides a (short) name, helping the log viewer staff interpreting the figure
        /// </summary>
        public string Key3Name { get; set; }

        /// <summary>
        /// Provides a key that can be used for grouping log results (as opposed to keywords that are used for filtering. 
        /// </summary>
        public string Key3Value { get; set; }

        /// <summary>
        /// Provides a (short) name, helping the log viewer staff interpreting the figure
        /// </summary>
        public string Key4Name { get; set; }

        /// <summary>
        /// Provides a key that can be used for grouping log results (as opposed to keywords that are used for filtering. 
        /// </summary>
        public string Key4Value { get; set; }
    }
}
