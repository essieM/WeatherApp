// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WeatherAppSample.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView img { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelCityName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelMax { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelMin { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (img != null) {
                img.Dispose ();
                img = null;
            }

            if (labelCityName != null) {
                labelCityName.Dispose ();
                labelCityName = null;
            }

            if (labelDate != null) {
                labelDate.Dispose ();
                labelDate = null;
            }

            if (labelMax != null) {
                labelMax.Dispose ();
                labelMax = null;
            }

            if (labelMin != null) {
                labelMin.Dispose ();
                labelMin = null;
            }
        }
    }
}