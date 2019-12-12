using System;
using System.Linq;
using System.Windows.Markup;
using System.Windows.Media;

namespace MaterialDesignThemes.CustomResources
{
    /// <summary>
    /// A custom <see cref="MarkupExtension"/> to fight WPF
    /// memory leak when using Font resources.
    /// <example>
    ///  FontFamily="{customResources:FontResource FontName=Roboto}"
    /// </example>
    /// </summary>
    public class FontResource : MarkupExtension
    {
        #region Constructors

        /// <summary>
        /// Initializes static members of the <see cref="FontResource"/> class.
        /// Extract the Roboto font family from Material Design Themes resources and cache it
        /// </summary>
        static FontResource()
        {
            foreach (FontFamily fontFamily in Fonts.GetFontFamilies(new Uri("pack://application:,,,/"), "./MaterialDesignThemes.Wpf/Resources/Roboto"))
            {
                FontCache.Instance.Add(fontFamily.FamilyNames.First().Value, fontFamily);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the font family named contained in the Material Design Themes resources
        /// </summary>
        public string FontName { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The ProvideValue
        /// </summary>
        /// <param name="serviceProvider">The serviceProvider<see cref="IServiceProvider"/></param>
        /// <returns>The <see cref="object"/></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return ReadFont();
        }

        /// <summary>
        /// Retrieves a Font from the cache
        /// </summary>
        /// <returns>The <see cref="object"/></returns>
        private object ReadFont()
        {
            if (!string.IsNullOrEmpty(FontName))
            {
                if (FontCache.Instance.ContainsKey(FontName))
                    return FontCache.Instance[FontName];
            }

            return new FontFamily("Roboto");
        }

        #endregion
    }
}
