﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LetterService
{
    [ServiceContract]
    public interface ILetterService
    {
        [OperationContract]
        int GetTimes(string firstStr, string secondStr);
    }
}
