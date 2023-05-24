using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public enum EnumEpicStatus
    {     
            Approved = 0,
            WaitingDeployment = 1,
            WaitingQA = 2,
            QAInProgress = 3,
            Rollback = 4,
            ProductDelivered = 5,     
    }
}
