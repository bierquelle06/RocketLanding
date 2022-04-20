using System;
using System.Collections.Generic;
using System.Text;

namespace RocketLanding.Business
{
    public class ErrorMessages
    {
        public static string _platformSizeUnderZero = "The platform size can not be under 0.";
        public static string _cannotbegreaterThanPlatformSize = "The safe area size can not be greater than platform size.";
        public static string _areCannotBeBelowXandYStartPosition = "The safe area start position of X and Y can not be below 0.";
        public static string _areaIsOutOfThePlatform = "The safe area is out of the platform. Check X and Y coordinates of the safe area starting positions.";
    }
}
