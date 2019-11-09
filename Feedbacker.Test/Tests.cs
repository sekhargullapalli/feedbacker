using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Feedbacker.Test
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AnalyticsTest()
        {    

            AppResult[] results = app.WaitForElement(c => c.Button("Red"));
            for(int i = 2; i < 10; i++)
            {
                if (i%2==0)
                    app.Tap(c => c.Button("Red"));
                if (i % 3 == 0)
                    app.Tap(c => c.Button("Blue"));
                if (i % 4 == 0)
                    app.Tap(c => c.Button("Green"));
            }
            Assert.IsTrue(results.Any());
        }
    }
}
