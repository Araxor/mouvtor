using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouvtorCommon
{
    public class Path : List<PathStep>
    {
        #region Properties
        public long Timestamp {get;  private set;}
        private int CheckedPoint { get; set; }
        #endregion

        #region Constructor
        public Path(long timestamp)
        {
            Timestamp = timestamp;
            this.CheckedPoint = 0;
        }

        public Path(long timestamp, IEnumerable<PathStep> points)
            : this(timestamp)
        {
            AddRange(points);
        }
        #endregion

        #region Methodes
        public void DeleteUselessPoint()
        {
            List<PathStep> removed = new List<PathStep>();

            for(int i = this.CheckedPoint + 1; i < this.Count - 1; ++i)
                removed.Add(this[i]);

            for (int i = 0; i < removed.Count; ++i)
                this.Remove(removed[i]);

            this.CheckedPoint++;
        }
        #endregion
    }
}
