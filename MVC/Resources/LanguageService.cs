using Microsoft.Extensions.Localization;
using System.Reflection;

namespace MVC.Resources
{
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;
        public LanguageService(IStringLocalizer<LanguageService> localizer, IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name);
            //_localizer = localizer;
        }

        public LocalizedString GetLocalizedHTML(string key)
        {
            return _localizer[key];
        }
    }
}
