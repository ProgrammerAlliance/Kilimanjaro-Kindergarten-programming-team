﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.YummyCate.Model
{
    public class OperationResult<T>
    {
        public string Message { get; set; }

        public T Result { get; set; }

        public AuthorityEnum Authority { get; set; }
        public OrderingStateEnum OrderingState { get; set; }

        public override string ToString()
        {
            return Message + "-" + Result.ToString() + "-" + OrderingState.ToString();
        }
    }
}