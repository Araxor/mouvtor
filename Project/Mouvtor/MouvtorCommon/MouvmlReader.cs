﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MouvtorCommon
{
    public class MouvmlReader : IEnumerable<Path>
    {
        #region Private properties
        private string Path { get; set; }
        #endregion

        #region Constructor
        public MouvmlReader(string path)
        {
            Path = path;
        }
        #endregion

        #region IEnumerable implementation
        public IEnumerator<Path> GetEnumerator()
        {
            return parsePaths().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        #region Private methods
        private IEnumerable<Path> parsePaths()
        {
            var document = XDocument.Load(Path);
            foreach (var pathElement in document.Elements("path"))
            {
                yield return new Path(
                    Convert.ToInt64(pathElement.Attribute("timestamp").Value), 
                    parsePath(pathElement)
                );
            }
        }

        private IEnumerable<PathStep> parsePath(XElement element)
        {
            foreach (var pointElement in element.Elements("point"))
            {
                yield return new PathStep(
                        Convert.ToDouble(pointElement.Attribute("x").Value),
                        Convert.ToDouble(pointElement.Attribute("y").Value),
                        Convert.ToDouble(pointElement.Attribute("z").Value),
                        Convert.ToInt64(pointElement.Attribute("timestamp").Value)
                );
            }
        }
        #endregion
    }
}
