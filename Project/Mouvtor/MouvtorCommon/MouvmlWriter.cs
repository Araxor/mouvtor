using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MouvtorCommon
{
    class MouvmlWriter
    {
        const string MOUVML_VERSION = "0.1";
        private XDocument Document { get; set; }
        private XElement RootElement { get; set; }
        private string Path { get; set; }

        public MouvmlWriter(string path) 
        {
            Path = path;
            InitDocument();
        }

        private void InitDocument()
        {
            Document = new XDocument();
            RootElement = new XElement("mouvml", new XAttribute("version", MOUVML_VERSION));
            Document.Add(RootElement);
        }

        public void AddPath(IEnumerable<PathStep> path)
        {
            var PathElement = new XElement("path");

            foreach (var step in path)
            {
                PathElement.Add("point", 
                    new XAttribute("x", step.NormalizedPosition.X),
                    new XAttribute("y", step.NormalizedPosition.Y),
                    new XAttribute("z", step.NormalizedPosition.Z),
                    new XAttribute("timestamp", step.Timestamp)
                );
            }

            RootElement.Add(PathElement);
        }

        public void AddPaths(IEnumerable<IEnumerable<PathStep>> paths)
        {
            foreach (var path in paths)
            {
                AddPath(path);
            }
        }

        public void Save() 
        {
            Document.Save(Path);
        }
    }
}
