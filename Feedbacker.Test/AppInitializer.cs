using System;
using System.IO;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Feedbacker.Test
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {

                //var path = System.AppDomain.CurrentDomain.BaseDirectory;

                //path = Directory.GetParent(path).Parent.Parent.Parent.FullName;
                //path = Path.Combine(path, "Feedbacker/Feedbacker.Android/bin/Release/com.companyname.feedbacker-Signed.apk");

                //return ConfigureApp
                //    .Android
                //    .EnableLocalScreenshots()
                //    .ApkFile(path)
                //    .StartApp();                

                return ConfigureApp
                    .Android
                    .EnableLocalScreenshots()                    
                    .StartApp();



            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}