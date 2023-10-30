using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.MessageContracts.Abstract
{
    public interface  IReportRequest
    {
        public string Data { get; set; }
    }
    public class ReportRequest: IReportRequest
    {
        public string Data { get; set; }
    }
}
