using System;

namespace FirstHibernate.Items
{
    public class PopEval
    {
        public virtual string Cn { get; set; }
        public virtual string EvalGrpCn { get; set; }
        public virtual int Rscd { get; set; }
        public virtual int Evalid { get; set; }
        public virtual string EvalDescr { get; set; }
        public virtual int Statecd { get; set; }
        public virtual string LocationNm { get; set; }
        public virtual string ReportYearNm { get; set; }
        
        public virtual int? StartInvyr { get; set; }
        public virtual int? EndInvyr { get; set; }
        
        public virtual string LandOnly { get; set; }
        public virtual string TimberlandOnly { get; set; }
        public virtual string GrowthAcct { get; set; }
        public virtual string EstnMethod { get; set; }
        public virtual string Notes { get; set; }
        
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedInInstance { get; set; }
        
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedInInstance { get; set; }
    }
}
