using Munchkin.BL.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Munchkin.Tests.Munchkin.Model.Tests.Helper
{
    public class ReadLineOverrideTests
    {
        [Fact]
        public void GetNextString()
        {
            //Arrange
            ReadLineOverride test = new TestReadLine();
            //Act
            var result = test.GetNextString();
            //Assert
            result.Should().Be("1,2,3,4");
            typeof(TestReadLine).Should().BeDerivedFrom<ReadLineOverride>();
        }
    }

    internal class TestReadLine : ReadLineOverride
    {
        public override string GetNextString()
        {
            return "1,2,3,4";
        }
    }
}
