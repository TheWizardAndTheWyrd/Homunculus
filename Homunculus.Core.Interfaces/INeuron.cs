﻿using System;
using System.Collections.Generic;

namespace Homunculus.Core.Interfaces
{
    public interface INeuron
    {
        Guid Id { get; }
        Tuple<float, float, float> Weights { get; set; }
        IEnumerable<float> Input { get; set; }
        double Output { get; }
        int Accumulator { get; set; }
    }
}