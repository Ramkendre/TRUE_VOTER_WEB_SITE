using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for insertfeedbackBll
/// </summary>
public class insertfeedbackBll
{
    insertfeedbackDLL insertdll = new insertfeedbackDLL();
	public insertfeedbackBll()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int insertfeebackinfobll(string subject, string message, int type, string insertiondate, string regid)
    {
        
        return insertdll.insertfeedbackinfo(subject, message, type, insertiondate, regid);
        
    }
}