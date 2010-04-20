using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace PhoneGapWindows
{
    class GeolocationCommand : ICommand
    {
        #region ICommand Members

        public string execute(string instruction, string[] parameters)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("http://www.geoplugin.net/xml.gp");
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            //ns.AddNamespace("", "http://www.geoplugin.net/xml.gp");  
            String lat = doc.SelectSingleNode("/geoPlugin/geoplugin_latitude", ns).InnerText;
            String lng = doc.SelectSingleNode("/geoPlugin/geoplugin_longitude", ns).InnerText;
            return "navigator.geolocation.setLocation(new Position(new Coordinates('" + lat + "', '" + lng + "')))";
        }

        public bool accept(string instruction)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
