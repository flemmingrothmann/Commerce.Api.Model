using System;

namespace CommerceClient.Api.Model
{
    [Serializable]
    public abstract class ResponseBase
    {
        /// <summary>
        /// Represents a unique ID for the task carried out by a request. An Id relates to the job done, f.inst. update product descriptions.
        /// The Id serves as an identifier for querying status of a task. This gives frontend developers a tool to request an async, long running task, allowing to query the progress / status of this task.
        /// The Id also serves a handle for ScanCommerce support in case the request needs inevstigation, f.inst if a failure occurs.
        /// Id is an abitrary string of max 50 characters. It implies no meaning of its own, and has no predictable format or sequence.
        /// The Id is required in Api response.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Echoes the context from original request. This should be a client supplied identifier, enabling frontend developers to pair response with original request, thereby encouraging async programming models.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// This states a name of the actual server serving the response. This has no practical use other but supplying an ensurance of the platform in service.
        /// </summary>
        public string ServedBy { get; }

        /// <summary>
        /// Returns the time in UTC when the request was created. 
        /// </summary>
        public string TimeServed { get; }

        /// <summary>
        /// Returns the <see cref="!:Core.AppSettings.ApplicationBuildText" />
        /// </summary>
        public string AppVersion { get; }

        /// <summary>
        /// Returns the complete time it took to process the request, based on the <see cref="!:Model.ResponseArgs.StartTime" />.
        /// </summary>
        public double? Took { get; }
    }
}