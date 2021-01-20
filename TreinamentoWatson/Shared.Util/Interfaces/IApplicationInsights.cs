using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Util.Interfaces
{
    public interface IApplicationInsights
    {
        void EnviaException(Exception exception);
    }
}
