using System.Collections.Generic;

namespace SoilTestReader
{
    /// <summary>
    /// Defines an interface for reading reports
    /// </summary>
    internal interface IReportReader
    {
        /// <summary>
        /// Read a report from a filepath
        /// </summary>
        /// <param name="filepath">Path to the report to be read</param>
        /// <param name="soilReports">The output reports</param>
        /// <returns>Whether the read was successful</returns>
        bool TryReadReport(string filepath, out RawReport rawReportText);

        /// <summary>
        /// Validate a filepath, such as for proper file extension
        /// </summary>
        /// <param name="filepath">Path to validate</param>
        /// <returns>Whether the path is valid</returns>
        bool ValidatePath(string filepath);
    }
}