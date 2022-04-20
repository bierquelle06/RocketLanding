using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLanding.Business
{
    /// <summary>
    /// Landing Area
    /// </summary>
    public class LandingArea
    {
        /// <summary>
        /// Create Area And Platform
        /// </summary>
        /// <param name="platformSize"></param>
        /// <param name="platformStartX"></param>
        /// <param name="platformStartY"></param>
        /// <param name="areaSize"></param>
        public int[,] CreateAreaAndPlatform(int platformSize, int platformStartX, int platformStartY, int areaSize = 100)
        {
            if (platformSize < 0)
                throw new InvalidOperationException(ErrorMessages._platformSizeUnderZero);

            if (platformSize > areaSize || platformSize > areaSize)
                throw new InvalidOperationException(ErrorMessages._cannotbegreaterThanPlatformSize);

            if (platformStartX < 0 || platformStartY < 0)
                throw new InvalidOperationException(ErrorMessages._areCannotBeBelowXandYStartPosition);

            if (!Validations.IsValidCheckSafeArea(platformSize, platformStartX, platformStartY, areaSize))
                throw new InvalidOperationException(ErrorMessages._areaIsOutOfThePlatform);

            int[,] landingArea = new int[areaSize, areaSize];

            // For the platform coordinates set 1, out of the platform set 0
            for (int i = platformStartX; i < platformStartX + platformSize; i++)
            {
                for (int j = platformStartY; j < platformStartY + platformSize; j++)
                {
                    landingArea[i, j] = 1;
                }
            }

            return landingArea;
        }

    }
}
