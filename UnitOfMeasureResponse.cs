namespace Commerce.Api.Model
{
    public class UnitOfMeasureResponse
    {
        public int UnitOfMeasureId { get; set; }
        public string ExtUnitOfMeasureId { get; set; }

        /// <summary>
        /// Short notation of the unit. Try using abbreviations familiar to your clients.
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Indicates if the unit is a standardized unit (f.inst kilo) or non-standardized unit (f.inst box or pallet)
        /// aka SiUnit
        /// </summary>
        public string SiUnit { get; set; }

        /// <summary>
        /// Indicates how this unit mathematical relates to its base unit.
        /// Base units will have conversion factor 1.
        /// </summary>
        public decimal ConversionFactor { get; set; }

        /// <summary>
        /// If this unit relates to another unit. All units with the same base can be converted between each other.
        /// </summary>
        public int? BaseUnitOfMeasureId { get; set; }

        /// <summary>
        /// A more elaborate description of this unit. Try using terms familiar to your clients.
        /// </summary>
        public string Description { get; set; }
    }
}