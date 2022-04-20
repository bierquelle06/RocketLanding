using System;
using Xunit;

using RocketLanding.Business;

namespace RocketLanding.Test
{
    public class LandingTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="platformSize"></param>
        /// <param name="platformStartX"></param>
        /// <param name="platformStartY"></param>
        /// <param name="landX"></param>
        /// <param name="landY"></param>
        /// <param name="areaSize"></param>
        [Theory]
        [InlineData(10, 5, 5, 6, 6, 100)]
        [InlineData(10, 60, 5, 65, 14, 100)]
        [InlineData(10, 60, 5, 69, 14, 100)]
        [InlineData(20, 40, 5, 48, 24, 100)]
        [InlineData(10, 0, 0, 0, 0, 100)]
        public void RocketBusiness_WhenOkForLanding(int platformSize, int platformStartX, int platformStartY, int landX, int landY, int areaSize)
        {
            // Arrange
            var landingArea = new LandingArea();
            var resultArea = landingArea.CreateAreaAndPlatform(platformSize, platformStartX, platformStartY, areaSize);

            var rocket = new Rocket
            {
                Name = NameGenerator.GenerateName(),
                PositionX = landX,
                PositionY = landY
            };

            //Action
            Validations validations = new Validations();

            var result = validations.CheckLandingArea(rocket, resultArea, areaSize);

            //Assert
            Assert.Equal(LandingEnums.OkForLanding, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="platformSize"></param>
        /// <param name="platformStartX"></param>
        /// <param name="platformStartY"></param>
        /// <param name="landX"></param>
        /// <param name="landY"></param>
        /// <param name="areaSize"></param>
        [Theory]
        [InlineData(10, 5, 5, 16, 16, 100)]
        [InlineData(10, 60, 5, 20, 14, 100)]
        [InlineData(20, 40, 5, 12, 24, 100)]
        [InlineData(10, 0, 0, 11, 0, 100)]
        [InlineData(10, 60, 5, 60, 15, 100)]
        [InlineData(10, 60, 5, 69, 15, 100)]
        [InlineData(10, 60, 5, 70, 15, 100)]
        public void RocketBusiness_WhenOutOfPlatform(int platformSize, int platformStartX, int platformStartY, int landX, int landY, int areaSize)
        {
            // Arrange
            var landingArea = new LandingArea();
            var resultArea = landingArea.CreateAreaAndPlatform(platformSize, platformStartX, platformStartY);

            var rocket = new Rocket
            {
                Name = NameGenerator.GenerateName(),
                PositionX = landX,
                PositionY = landY
            };

            //Action
            Validations validations = new Validations();

            var result = validations.CheckLandingArea(rocket, resultArea, areaSize);

            //Assert
            Assert.Equal(LandingEnums.OutOfPlatform, result);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void RocketLib_WhenClashAndOkForMultiRockets()
        {
            // Arrange
            var landingArea = new LandingArea();
            int platformSize = 20;
            int platformStartX = 5;
            int platformStartY = 5;

            int areaSize = 100;

            var resultLandingArea = landingArea.CreateAreaAndPlatform(platformSize, platformStartX, platformStartY);

            var rocket1 = new Rocket
            {
                Name = NameGenerator.GenerateName(),
                PositionX = 12,
                PositionY = 7
            };

            var rocket2 = new Rocket
            {
                Name = NameGenerator.GenerateName(),
                PositionX = 11,
                PositionY = 6
            };

            var rocket3 = new Rocket
            {
                Name = NameGenerator.GenerateName(),
                PositionX = 12,
                PositionY = 5
            };

            var rocket4 = new Rocket
            {
                Name = NameGenerator.GenerateName(),
                PositionX = 24,
                PositionY = 8
            };

            //Action
            Validations validations = new Validations();

            var result1 = validations.CheckLandingArea(rocket1, resultLandingArea, areaSize);
            Assert.Equal(LandingEnums.OkForLanding, result1);

            var result2 = validations.CheckLandingArea(rocket2, resultLandingArea, areaSize);
            Assert.Equal(LandingEnums.Clash, result2);

            var result3 = validations.CheckLandingArea(rocket3, resultLandingArea, areaSize);
            Assert.Equal(LandingEnums.Clash, result3);

            var result4 = validations.CheckLandingArea(rocket4, resultLandingArea, areaSize);
            Assert.Equal(LandingEnums.OkForLanding, result4);
        }
    }
}
