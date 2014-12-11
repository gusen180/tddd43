using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace tddd43.Helpers
{
    class GameXml
    {
        public GameXml()
        {
            XNamespace empNM = "urn:lst-emp:emp";

            XDocument xDoc = new XDocument(
                        new XDeclaration("1.0", "UTF-16", null),
                        new XElement("Game",
                                new XElement("Solution",
                                    new XElement("Spot0", 6),
                                    new XElement("Spot1", 6),
                                    new XElement("Spot2", 6),
                                    new XElement("Spot3", 6)
                            ),
                            new XElement("Rows",
                                new XElement("Row",
                                    new XElement("RowNr", 0),
                                    new XElement("Spot0", 7),
                                    new XElement("Spot1", 7),
                                    new XElement("Spot2", 7),
                                    new XElement("Spot3", 7),
                                    new XElement("Score0", 8),
                                    new XElement("Score1", 8),
                                    new XElement("Score2", 8),
                                    new XElement("Score3", 8),
                                    new XElement("CurrentRow", true)
                            ), new XElement("Row",
                                    new XElement("RowNr", 1),
                                    new XElement("Spot0", 7),
                                    new XElement("Spot1", 7),
                                    new XElement("Spot2", 7),
                                    new XElement("Spot3", 7),
                                    new XElement("Score0", 8),
                                    new XElement("Score1", 8),
                                    new XElement("Score2", 8),
                                    new XElement("Score3", 8),
                                    new XElement("CurrentRow", false)
                            ), new XElement("Row",
                                    new XElement("RowNr", 2),
                                    new XElement("Spot0", 7),
                                    new XElement("Spot1", 7),
                                    new XElement("Spot2", 7),
                                    new XElement("Spot3", 7),
                                    new XElement("Score0", 8),
                                    new XElement("Score1", 8),
                                    new XElement("Score2", 8),
                                    new XElement("Score3", 8),
                                    new XElement("CurrentRow", false)
                            ), new XElement("Row",
                                    new XElement("RowNr", 3),
                                    new XElement("Spot0", 7),
                                    new XElement("Spot1", 7),
                                    new XElement("Spot2", 7),
                                    new XElement("Spot3", 7),
                                    new XElement("Score0", 8),
                                    new XElement("Score1", 8),
                                    new XElement("Score2", 8),
                                    new XElement("Score3", 8),
                                    new XElement("CurrentRow", false)
                            ), new XElement("Row",
                                    new XElement("RowNr", 4),
                                    new XElement("Spot0", 7),
                                    new XElement("Spot1", 7),
                                    new XElement("Spot2", 7),
                                    new XElement("Spot3", 7),
                                    new XElement("Score0", 8),
                                    new XElement("Score1", 8),
                                    new XElement("Score2", 8),
                                    new XElement("Score3", 8),
                                    new XElement("CurrentRow", false)
                            ), new XElement("Row",
                                    new XElement("RowNr", 5),
                                    new XElement("Spot0", 7),
                                    new XElement("Spot1", 7),
                                    new XElement("Spot2", 7),
                                    new XElement("Spot3", 7),
                                    new XElement("Score0", 8),
                                    new XElement("Score1", 8),
                                    new XElement("Score2", 8),
                                    new XElement("Score3", 8),
                                    new XElement("CurrentRow", false)
                            ), new XElement("Row",
                                    new XElement("RowNr", 6),
                                    new XElement("Spot0", 7),
                                    new XElement("Spot1", 7),
                                    new XElement("Spot2", 7),
                                    new XElement("Spot3", 7),
                                    new XElement("Score0", 8),
                                    new XElement("Score1", 8),
                                    new XElement("Score2", 8),
                                    new XElement("Score3", 8),
                                    new XElement("CurrentRow", false)
                            ), new XElement("Row",
                                    new XElement("RowNr", 7),
                                    new XElement("Spot0", 7),
                                    new XElement("Spot1", 7),
                                    new XElement("Spot2", 7),
                                    new XElement("Spot3", 7),
                                    new XElement("Score0", 8),
                                    new XElement("Score1", 8),
                                    new XElement("Score2", 8),
                                    new XElement("Score3", 8),
                                    new XElement("CurrentRow", false)
                            ), new XElement("Row",
                                    new XElement("RowNr", 8),
                                    new XElement("Spot0", 7),
                                    new XElement("Spot1", 7),
                                    new XElement("Spot2", 7),
                                    new XElement("Spot3", 7),
                                    new XElement("Score0", 8),
                                    new XElement("Score1", 8),
                                    new XElement("Score2", 8),
                                    new XElement("Score3", 8),
                                    new XElement("CurrentRow", false)
                            ), new XElement("Row",
                                    new XElement("RowNr", 9),
                                    new XElement("Spot0", 7),
                                    new XElement("Spot1", 7),
                                    new XElement("Spot2", 7),
                                    new XElement("Spot3", 7),
                                    new XElement("Score0", 8),
                                    new XElement("Score1", 8),
                                    new XElement("Score2", 8),
                                    new XElement("Score3", 8),
                                    new XElement("CurrentRow", false)
                            )), new XElement("Ai", null)
                            ));

            StringWriter sw = new StringWriter();
            XmlWriter xWrite = XmlWriter.Create(sw);
            xDoc.Save(xWrite);
            xWrite.Close();

            // Save to Disk
            xDoc.Save("XmlData.xml");
        }

    }
}
