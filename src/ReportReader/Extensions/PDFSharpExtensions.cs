using System.Collections.Generic;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Content;
using PdfSharp.Pdf.Content.Objects;

/// <summary>
/// Provides extensions for PDFSharp such as those used for reading files
/// </summary>
/// <remarks>
/// Courtesy @"Ronnie Overby" - https://stackoverflow.com/a/24046096
/// </remarks>
public static class PdfSharpExtensions
{
    public static IEnumerable<string> ExtractText(this PdfPage page)
    {
        var content = ContentReader.ReadContent(page);
        var text = content.ExtractText();
        return text;
    }

    public static IEnumerable<string> ExtractText(this CObject cObject)
    {
        if (cObject is COperator)
        {
            var cOperator = cObject as COperator;
            if (cOperator.OpCode.Name == OpCodeName.Tj.ToString() ||
                cOperator.OpCode.Name == OpCodeName.TJ.ToString())
            {
                foreach (var cOperand in cOperator.Operands)
                    foreach (var txt in ExtractText(cOperand))
                        yield return txt;
            }
        }
        else if (cObject is CSequence)
        {
            var cSequence = cObject as CSequence;
            foreach (var element in cSequence)
                foreach (var txt in ExtractText(element))
                    yield return txt;
        }
        else if (cObject is CString)
        {
            var cString = cObject as CString;
            yield return cString.Value;
        }
    }
}