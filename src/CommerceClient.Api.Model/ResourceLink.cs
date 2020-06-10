namespace CommerceClient.Api.Model
{
    public class ResourceLink
    {
        /// <summary>
        /// Specifies what relation this link has to the resource it is declared upon.
        /// </summary>
        public string Rel { get; set; }

        /// <summary>
        /// Specifies the link to the resource. This would be a relative link.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Represents the action suggested to use the resource.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// The title of the resource, that describes the link.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// If the resource has a logical distance from the actual data, f.inst a nested level or inheritance.
        /// </summary>
        public int? NestedLevel { get; set; }

        /// <summary>
        /// For image resources, this represents the image type of the request.
        /// </summary>
        public int? SizeTypeId { get; set; }

        /// <summary>
        /// An abstract content type describing what kind of data to expect from the resource.
        /// </summary>
        public string TargetContent { get; set; }

        /// <summary>
        /// Describes what media type to expect from the resource in a technical described as mime.
        /// </summary>
        public string TargetMediaType { get; set; }
    }
}