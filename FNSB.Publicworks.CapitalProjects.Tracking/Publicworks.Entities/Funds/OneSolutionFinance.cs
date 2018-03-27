

namespace Publicworks.Entities.Funds
{
    public class OneSolutionFinance
    {

    //01	4       	FGRP Fund Group Enterprise Fund Group         
    //02	45      	FUND Fund    Carlson Center Projects       
    //03	93      	FUNC Function    Carlson center enterprise fund
    //04	LPB         AGCY Funding Agency  LOCAL CONT PUBLIC BOND SALES  
    //05	08      	DEPT Department  Public works                  
    //06	415     	DIVN Division    DESIGN & CONSTRUCTION         
    //07	999     	SECT Section/SVC Area    N/A                           
    //08	6CV         SUBS Sub Section CAC ROOF & HVAC CONTROL SYSTEM

        public string GeneralLedgerKey { get; set; }
        public string GeneralLedgerDesc { get; set; }
        public decimal BudgetBalance { get; set; }
        public decimal ActualsBalance { get; set; }
        public string KeyStatus { get; set; }
        public decimal EncumbranceBalance { get; set; }
        public OneSolutionKeyPartDetail KeyPart01 { get; set; }
        public OneSolutionKeyPartDetail KeyPart02 { get; set; }
        public OneSolutionKeyPartDetail KeyPart03 { get; set; }
        public OneSolutionKeyPartDetail KeyPart04 { get; set; }
        public OneSolutionKeyPartDetail KeyPart05 { get; set; }
        public OneSolutionKeyPartDetail KeyPart06 { get; set; }
        public OneSolutionKeyPartDetail KeyPart07 { get; set; }
        public OneSolutionKeyPartDetail KeyPart08 { get; set; }
        public string JobLedgerProject { get; set; }
    }
}
