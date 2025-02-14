using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ClassDemoConfigogLog
{
    public  class ReadConfig
    {

        public void Start()
        {
            string name = "";
            int port = 0;

            XmlDocument configXML = new XmlDocument();
            configXML.Load("../../../Config.xml");

            XmlNode? NameXml = configXML.DocumentElement.SelectSingleNode("Name");
            if (NameXml != null)
            {
                name = NameXml.InnerText;
            }

            XmlNode? PortXml = configXML.DocumentElement.SelectSingleNode("Port");
            if (PortXml != null)
            {
                string portTxt = PortXml.InnerText.Trim();
                port = Convert.ToInt32(portTxt);
            }


            XmlNode? ImNullXml = configXML.DocumentElement.SelectSingleNode("IamNull");
            if (ImNullXml == null || ImNullXml.Attributes["xsi:nil"]?.Value == "true")
            {
                Console.WriteLine("i am null");
            }
            else
            {
                Console.WriteLine("text::" + ImNullXml.InnerText.Trim() + "::");
            }

            Console.WriteLine("Name is " + name + " the port number is " + port);
        }
    }
}
