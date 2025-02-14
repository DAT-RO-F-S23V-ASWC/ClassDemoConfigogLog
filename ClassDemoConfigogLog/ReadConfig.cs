using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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


            Console.WriteLine("Name is " + name + " the port number is " + port);
        }
    }
}
