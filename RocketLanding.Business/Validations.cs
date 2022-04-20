using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLanding.Business
{
    public class Validations
    {
        #region Constructors

        private LastAreasDto _lastCheckedAreas = new LastAreasDto() { AreaX = -1, AreaY = -1 };

        private const int Seperation = 1;

        #endregion

        /// <summary>
        /// Rocket Check Landing Area
        /// </summary>
        /// <param name="rocket"></param>
        /// <returns></returns>
        public LandingEnums CheckLandingArea(Rocket rocket, int[,] landingArea, int areaSize)
        {
            LandingEnums result = LandingEnums.Unknown;

            if (!rocket.PositionX.HasValue || rocket.PositionX < 0 || rocket.PositionX > areaSize)
                throw new Exception($"Rocket coordinates are not valid! Values must be in 0x0 to {areaSize}x{areaSize}");

            if (!rocket.PositionY.HasValue || rocket.PositionY < 0 || rocket.PositionY > areaSize)
                throw new Exception($"Rocket coordinates are not valid! Values must be in 0x0 to {areaSize}x{areaSize}");

            if (!InPlatformAreaControl(rocket, landingArea))
                result = LandingEnums.OutOfPlatform;
            else if (InLastCheckedAreaControl(rocket))
                result = LandingEnums.Clash;
            else
                result = LandingEnums.OkForLanding;

            _lastCheckedAreas.AreaX = rocket.PositionX.Value;
            _lastCheckedAreas.AreaY = rocket.PositionY.Value;

            Console.WriteLine($"{rocket.Name} > {_lastCheckedAreas.AreaX}x{_lastCheckedAreas.AreaY} : {result}");

            return result;
        }

        /// <summary>
        /// Is Valid Check Safe Area
        /// </summary>
        /// <param name="platformSize"></param>
        /// <param name="platformStartX"></param>
        /// <param name="platformStartY"></param>
        /// <param name="areaSize"></param>
        /// <returns></returns>
        public static bool IsValidCheckSafeArea(int platformSize, int platformStartX, int platformStartY, int areaSize)
        {
            bool result = true;

            if (((platformStartX + platformSize) > areaSize) || ((platformStartY + platformSize) > areaSize))
                result = false;

            return result;
        }

        /// <summary>
        /// In The Platform Area Control
        /// </summary>
        /// <param name="rocket"></param>
        /// <param name="landingArea"></param>
        /// <returns></returns>
        private bool InPlatformAreaControl(Rocket rocket, int[,] landingArea)
        {
            return Convert.ToBoolean(landingArea[rocket.PositionX ?? 0, rocket.PositionY ?? 0]);
        }

        /// <summary>
        /// In The Last Checked Area Control
        /// </summary>
        /// <param name="rocket"></param>
        /// <returns></returns>
        private bool InLastCheckedAreaControl(Rocket rocket)
        {
            //If not checked yet and this is the first checked, no need to run codes, return.
            if (_lastCheckedAreas.AreaX == -1)
                return false;

            if (_lastCheckedAreas.AreaY == -1)
                return false;

            //Min. and Max. for Area X
            int minX = _lastCheckedAreas.AreaX - Seperation;
            int maxX = _lastCheckedAreas.AreaX + Seperation;

            //Min. and Max. for Area Y
            int minY = _lastCheckedAreas.AreaY - Seperation;
            int maxY = _lastCheckedAreas.AreaY + Seperation;

            if (rocket.PositionX >= minX && rocket.PositionX <= maxX && rocket.PositionY >= minY && rocket.PositionY <= maxY)
                return true;

            return false;
        }
    }
}
