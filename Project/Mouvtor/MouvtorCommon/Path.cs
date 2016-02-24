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
        #endregion

        #region Constructor
        public Path(long timestamp)
        {
            Timestamp = timestamp;
        }

        public Path(long timestamp, IEnumerable<PathStep> points)
            : this(timestamp)
        {
            AddRange(points);
        }
        #endregion
    }
}
