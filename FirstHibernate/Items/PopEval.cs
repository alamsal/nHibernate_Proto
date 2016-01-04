using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstHibernate.Items
{
    public class PopEval
    {
        public virtual string cn { get; set; }
        public virtual string evalGrpCn { get; set; }
        public virtual int rscd { get; set; }
        public virtual int evalid { get; set; }
        public virtual string evalDescr { get; set; }
        public virtual int statecd { get; set; }
        public virtual string locationNm { get; set; }
        public virtual string reportYearNm { get; set; }
        public virtual int startInvyr { get; set; }
        public virtual int endInvyr { get; set; }
        public virtual string landOnly { get; set; }
        public virtual string timberlandOnly { get; set; }
        public virtual string growthAcct { get; set; }
        public virtual string estnMethod { get; set; }
        public virtual string notes { get; set; }
        public virtual string createdBy { get; set; }
        public virtual DateTime createdDate { get; set; }
        public virtual string createdInInstance { get; set; }
        public virtual string modifiedBy { get; set; }
        public virtual DateTime modifiedDate { get; set; }
        public virtual string modifiedInInstance { get; set; }
    }
}
