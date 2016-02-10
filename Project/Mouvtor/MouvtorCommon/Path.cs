using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouvtorCommon
{
    public class Path : List<PathStep>
    {
        public long Timestamp {get;  private set;}

        public Path(long timestamp)
        {
            Timestamp = timestamp;
        }

        public Path(long timestamp, IEnumerable<PathStep> points)
            : this(timestamp)
        {
            AddRange(points);
        }
    }
}
