﻿// Copyright (c) 2018 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System.IO;
using System.Linq;
using ServiceLayer.DatabaseServices.Concrete;
using Xunit;
using Xunit.Extensions.AssertExtensions;
using TestSupport.Helpers;

namespace Tests.UnitTests.DDDEntities
{
    public class TestDddBookLoad
    {
        [Fact]
        public void TestLoadBooksOk()
        {
            //SETUP
            var testsDir = TestData.GetCallingAssemblyTopLevelDir();
            var dataDir = Path.GetFullPath($"{testsDir}{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}"+
                $"{nameof(ExampleWebApp)}{Path.DirectorySeparatorChar}wwwroot{Path.DirectorySeparatorChar}{DbSetupHelpers.SeedFileSubDirectory}");

            //ATTEMPT
            var books = BookJsonLoader.LoadBooks(dataDir,
                    DbSetupHelpers.SeedDataSearchName).ToList();

            //VERIFY
            books.Count.ShouldEqual(53);
            books.All(x => x.ActualPrice != 0).ShouldBeTrue();
        }



    }

}