using System;
using System.Collections.Generic;
using System.Linq;

namespace SoilTestReader
{
    /// <summary>
    /// Contains raw report data, grouped by page
    /// </summary>
    internal class RawReport
    {
        #region Construction

        /// <summary>
        /// Creates a <see cref="RawReport"/>
        /// </summary>
        /// <param name="rawPageTexts">List of lists of page text</param>
        public RawReport(IEnumerable<IEnumerable<string>> rawPageTexts)
        {
            if (rawPageTexts is null || rawPageTexts.Any(t => t is null))
                throw new ArgumentException(nameof(rawPageTexts));

            var pageList = new List<RawReportPage>();
            foreach(var rawPageText in rawPageTexts)
            {
                pageList.Add(new RawReportPage(rawPageText));
            }

            Pages = pageList;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The raw report pages
        /// </summary>
        public IEnumerable<RawReportPage> Pages { get; private set; }

        #endregion
    }
}