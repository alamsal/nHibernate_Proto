using System;

namespace FirstHibernate.Items
{
    public class PopEvalAttribute
    {
        public virtual string Cn { get; set; }
        public virtual string Evalcn { get; set; }
        public virtual int AttributeNbr { get; set; }
        public virtual int? Statecd { get; set; }

        public virtual string CreatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedInInstance { get; set; }

        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedInInstance { get; set; }

        // Bi-directional association between PEA_PEV_FK

        public virtual PopEval PopEval { get; set; }

    }
}
