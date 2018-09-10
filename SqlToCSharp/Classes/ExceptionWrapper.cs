using System;
using System.Xml.Linq;

namespace SqlToCSharp.Classes
{
    public class ExceptionWrapper
    {
        public ExceptionWrapper(Exception ex)
        {
            this.Message = ex.Message;
            this.Helplink = ex.HelpLink;
            this.StackTrace = ex.StackTrace;
            this.Source = ex.Source;
            if (ex.InnerException != null)
            {
                this.InnerException = new ExceptionWrapper(ex.InnerException);
            }
        }
        public string Message { get; set; }

        public string Source { get; set; }

        public string StackTrace { get; set; }

        public string Helplink { get; set; }

        public ExceptionWrapper InnerException { get; set; }

        private readonly string StringFormat = "Message: {0}" + Environment.NewLine + "Source: {1}" + Environment.NewLine + "Help Link: {2}" + Environment.NewLine + "Stack Trace: {3}";
        public override string ToString()
        {
            return String.Format(StringFormat, this.Message, this.Source, this.Helplink, this.StackTrace);
        }
        public string ToXmlString()
        {
            return ConvertToXml();
        }
        XElement GetXElement()
        {
            return new XElement("Exception",
                        new XElement(nameof(Message), Message),
                        new XElement(nameof(Source), Source),
                        new XElement(nameof(Helplink), Helplink),
                        new XElement(nameof(StackTrace), StackTrace),
                        this.InnerException != null ? this.InnerException.GetXElement() : null);
        }
        string ConvertToXml()
        {
            XDocument doc = new XDocument(this.GetXElement());
            string s = doc.ToString();
            return s;
        }
    }
}
