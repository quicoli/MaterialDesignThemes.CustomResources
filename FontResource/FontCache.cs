using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace MaterialDesignThemes.CustomResources
{
    public sealed class FontCache
    {
        private static readonly Lazy<Dictionary<string, FontFamily>>
            Lazy =
                new Lazy<Dictionary<string, FontFamily>>
                    (() => new Dictionary<string, FontFamily>());

        public static Dictionary<string, FontFamily> Instance => Lazy.Value;

        private FontCache()
        {
        }
    }
}