using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Linq;

namespace tddd43.Helpers
{
    class AiXml
    {
        public AiXml(List<int[]> list)
        {
            var xEle = new XElement("Combinations",
                from elm in list
                select new XElement("Combination",
                             new XAttribute("Spot0", elm[0]),
                             new XAttribute("Spot1", elm[1]),
                             new XAttribute("Spot2", elm[2]),
                             new XAttribute("Spot3", elm[3])
                           ));

            xEle.Save("AiXml.xml");
        }

        public static void UpdateData(List<int[]> list)
        {
            var xEle = new XElement("Combinations",
                from elm in list
                select new XElement("Combination",
                             new XAttribute("Spot0", elm[0]),
                             new XAttribute("Spot1", elm[1]),
                             new XAttribute("Spot2", elm[2]),
                             new XAttribute("Spot3", elm[3])
                           ));

            xEle.Save("AiXml.xml");
        }

    }
}
