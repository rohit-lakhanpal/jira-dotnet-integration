using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Panviva.JiraDotNetIntegration.Library.Helper;
using Xunit;

namespace Panviva.JiraDotNetIntegration.Library.Tests.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidatorTests
    {
        [Fact]
        public void Test_IsValidIpOrHostName_ValidIpReturnsTrue()
        {
            // Arrange
            var input = "192.168.1.1";

            // Act
            var result = input.IsValidIpOrHostName();

            // Assert
            Assert.Equal(true, result);
        }

        [Fact]
        public void Test_IsValidIpOrHostName_InvalidIpReturnsFalse_InvalidRegexp_1()
        {
            // Arrange
            var input = "192.168.1.1.56";

            // Act
            var result = input.IsValidIpOrHostName();

            // Assert
            Assert.Equal(false, result);
        }

        [Fact]
        public void Test_IsValidIpOrHostName_InvalidIpReturnsFalse_InvalidRegexp_2()
        {
            // Arrange
            var input = "192.168.1.257";

            // Act
            var result = input.IsValidIpOrHostName();

            // Assert
            Assert.Equal(false, result);
        }

        [Fact]
        public void Test_IsValidIpOrHostName_ValidHostNameReturnsTrue()
        {
            // Arrange
            var input = "www.example-host-7.com";

            // Act
            var result = input.IsValidIpOrHostName();

            // Assert
            Assert.Equal(true, result);
        }
    }
}
