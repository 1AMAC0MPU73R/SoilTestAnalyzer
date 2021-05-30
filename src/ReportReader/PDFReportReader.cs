using System.Collections.Generic;
using System.IO;
using System.Linq;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace SoilTestReader
{
    internal class PDFReportReader : IReportReader
    {
        #region Constants

        internal const string PDFExtension = "pdf";

        #endregion

        #region Methods

        /// <inheritdoc/>
        public bool TryReadReport(string path, out RawReport reportText)
        {
            reportText = null;
            var pageTexts = ReadPDFByPage(path);
            if (!pageTexts.Any() || pageTexts.All(pt => !pt.Any())) return false;

            reportText = new RawReport(pageTexts);
            return true;
        }

        /// <inheritdoc/>
        public bool ValidatePath(string path) => IsPDF(path);

        #endregion

        #region Helpers

        /// <summary>
        /// Read all pages of a soil test report
        /// </summary>
        /// <param name="path">Path the the file to read</param>
        /// <returns>List of read text lines</returns>
        /// <remarks>
        /// Leverages PDFSharp to read PDFs by page into a list of strings for parsing
        /// </remarks>
        internal IEnumerable<IEnumerable<string>> ReadPDFByPage(string path)
        {
            List<string> texts = new List<string>();
            using (PdfDocument document = PdfReader.Open(path))
            {
                foreach (PdfPage page in document.Pages)
                    yield return page.ExtractText();
            };
        }

        /// <summary>
        /// Assures the path is for a pdf file
        /// </summary>
        /// <param name="path">The path string to check</param>
        /// <returns>Whether the extension is pdf</returns>
        internal bool IsPDF(string path)
        {
            return Path.GetExtension(path).ToLower() == PDFExtension.ToLower();
        }

        #endregion
    }
}