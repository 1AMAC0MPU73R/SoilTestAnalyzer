using System;
using System.Collections.Generic;
using System.Linq;

namespace SoilTestReader
{
    /// <summary>
    /// Describes the raw text of a single report page
    /// </summary>
    internal class RawReportPage
    {
        #region Construction

        /// <summary>
        /// Constructs a <see cref="RawReportPage"/>
        /// </summary>
        /// <param name="texts">The raw report page text</param>
        public RawReportPage(IEnumerable<string> texts)
        {
            if (texts is null || texts.Any(s => s is null)) 
                throw new ArgumentException(nameof(texts));

            Text = texts;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets/Sets the raw report text for this page
        /// </summary>
        public IEnumerable<string> Text { get; private set; }

        #endregion
    }
}