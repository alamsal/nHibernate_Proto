using System;

namespace FirstHibernate.Items
{
    class PopEvalAttribute
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
    }
}
