namespace SmartData.Sample.DataContract
{
    /// <summary>
    /// Class used to map between object properties and corresponding SQL columns
    /// </summary>
    public class SqlColumnMapping
    {
        /// <summary>
        /// Name of the column which you would like to map from.
        /// This is the name of the column in the underline SQL.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        ///  Name of the property which you would like to map to.
        ///  This is the name of the property in the class.
        /// </summary>
        public string Target { get; set; }
    }
}
