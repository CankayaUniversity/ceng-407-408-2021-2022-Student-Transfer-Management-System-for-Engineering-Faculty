using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace StudentTransferManagementSystem.Data.Responses
{

    public class InstructorServiceResponse
    {
       
    }

	[XmlRoot(ElementName = "element")]
	public class Element
	{

		[XmlElement(ElementName = "name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "type")]
		public string Type { get; set; }

		[XmlElement(ElementName = "minOccurs")]
		public int MinOccurs { get; set; }

		[XmlElement(ElementName = "complexType")]
		public ComplexType ComplexType { get; set; }

		[XmlElement(ElementName = "IsDataSet")]
		public bool IsDataSet { get; set; }

		[XmlElement(ElementName = "UseCurrentLocale")]
		public bool UseCurrentLocale { get; set; }
	}

	[XmlRoot(ElementName = "sequence")]
	public class Sequence
	{

		[XmlElement(ElementName = "element")]
		public List<Element> Element { get; set; }
	}

	[XmlRoot(ElementName = "complexType")]
	public class ComplexType
	{

		[XmlElement(ElementName = "sequence")]
		public Sequence Sequence { get; set; }

		[XmlElement(ElementName = "choice")]
		public Choice Choice { get; set; }
	}

	[XmlRoot(ElementName = "choice")]
	public class Choice
	{

		[XmlElement(ElementName = "element")]
		public Element Element { get; set; }

		[XmlElement(ElementName = "minOccurs")]
		public int MinOccurs { get; set; }

		[XmlElement(ElementName = "maxOccurs")]
		public string MaxOccurs { get; set; }
	}

	[XmlRoot(ElementName = "schema")]
	public class Schema
	{

		[XmlElement(ElementName = "element")]
		public Element Element { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }

		[XmlElement(ElementName = "xmlns")]
		public object Xmlns { get; set; }

		[XmlElement(ElementName = "xs")]
		public string Xs { get; set; }

		[XmlElement(ElementName = "msdata")]
		public string Msdata { get; set; }
	}

	[XmlRoot(ElementName = "Table")]
	public class Table
	{

		[XmlElement(ElementName = "SicilNo")]
		public int SicilNo { get; set; }

		[XmlElement(ElementName = "UnvAd")]
		public string UnvAd { get; set; }

		[XmlElement(ElementName = "UnvAdEn")]
		public string UnvAdEn { get; set; }

		[XmlElement(ElementName = "PerAd")]
		public string PerAd { get; set; }

		[XmlElement(ElementName = "PerSoyad")]
		public string PerSoyad { get; set; }

		[XmlElement(ElementName = "Email")]
		public string Email { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }

		[XmlElement(ElementName = "rowOrder")]
		public int RowOrder { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "NewDataSet")]
	public class NewDataSet
	{

		[XmlElement(ElementName = "Table")]
		public List<Table> Table { get; set; }

		[XmlElement(ElementName = "xmlns")]
		public object Xmlns { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "diffgram")]
	public class Diffgram
	{

		[XmlElement(ElementName = "NewDataSet")]
		public NewDataSet NewDataSet { get; set; }

		[XmlElement(ElementName = "msdata")]
		public string Msdata { get; set; }

		[XmlElement(ElementName = "diffgr")]
		public string Diffgr { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "XMLResult")]
	public class XMLResult
	{

		[XmlElement(ElementName = "schema")]
		public Schema Schema { get; set; }

		[XmlElement(ElementName = "diffgram")]
		public Diffgram Diffgram { get; set; }
	}

	[XmlRoot(ElementName = "XMLResponse")]
	public class XMLResponse
	{

		[XmlElement(ElementName = "XMLResult")]
		public XMLResult XMLResult { get; set; }

		[XmlElement(ElementName = "xmlns")]
		public string Xmlns { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "Body")]
	public class Body
	{

		[XmlElement(ElementName = "XMLResponse")]
		public XMLResponse XMLResponse { get; set; }
	}

	[XmlRoot(ElementName = "Envelope")]
	public class Envelope
	{

		[XmlElement(ElementName = "Body")]
		public Body Body { get; set; }

		[XmlElement(ElementName = "soap")]
		public string Soap { get; set; }

		[XmlElement(ElementName = "xsi")]
		public string Xsi { get; set; }

		[XmlElement(ElementName = "xsd")]
		public string Xsd { get; set; }

		[XmlText]
		public string Text { get; set; }
	}
}
