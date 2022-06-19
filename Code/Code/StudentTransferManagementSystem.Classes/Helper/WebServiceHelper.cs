using StudentTransferManagementSystem.Data.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace StudentTransferManagementSystem.Classes.Helper
{
    public static class WebServiceHelper
    {
        public static List<Table> CallWebService()
        {
            var _url = "https://webservice.cankaya.edu.tr/webservice.asmx";
            var _action = "https://webservice.cankaya.edu.tr/webservice.asmx?WSDL";

            var users = new List<Table>();
            XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }


                XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(soapResult));
                var xmlWithoutNs = xmlDocumentWithoutNs.ToString();

                using (StringReader reader = new StringReader(xmlWithoutNs))
                {
                    var test = (Envelope)serializer.Deserialize(reader);
                    var user = test.Body.XMLResponse.XMLResult.Diffgram.NewDataSet;

                    foreach (var item in user.Table)
                    {
                        users.Add(item);
                    }
                }


                return users;
            }
        }

        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }

        public static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope()
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            var soapXML = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">
  <soapenv:Header/>
    <soapenv:Body>
        <tem:XML>
            <tem:method>9600</tem:method>
                 <tem:methodNo>1</tem:methodNo>
                              <tem:Params>11</tem:Params>
                            <tem:Key>Utfv6nu$</tem:Key>
                               <tem:Type>1</tem:Type>
                                 </tem:XML>
                               </soapenv:Body>
                             </soapenv:Envelope>";

            soapEnvelopeDocument.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>" + soapXML);

            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
