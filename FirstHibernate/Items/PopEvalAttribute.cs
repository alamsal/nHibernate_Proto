using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstHibernate.Items
{
    class PopEvalAttribute
    {
        public virtual string cn { get; set; }
        public virtual string evalcn { get; set; }
        public virtual int attributenbr { get; set; }
        public virtual int statecd { get; set; }

        public virtual string createdby { get; set; }
        public virtual DateTime createddate { get; set; }
        public virtual string createdininstance { get; set; }

        public virtual string modifiedby { get; set; }
        public virtual DateTime modifieddate { get; set; }
        public virtual string modifiedinstance { get; set; }
    }
}
