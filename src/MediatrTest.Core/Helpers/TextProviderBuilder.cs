using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MvvmCross.IoC;
using MvvmCross.Plugin.JsonLocalization;

namespace MediatrTest.Core.Helpers
{
    public class TextProviderBuilder : MvxTextProviderBuilder
    {
        public TextProviderBuilder() : base("MediatrTest.Core", "Resources/Translations", new MvxEmbeddedJsonDictionaryTextProvider(false))
        {
        }

        protected override IDictionary<string, string> ResourceFiles
        {
            get
            {
                var dictionary = GetType().GetTypeInfo()
                                     .Assembly
                                     .CreatableTypes()
                                     .Where(t => t.Name.EndsWith("ViewModel"))
                                     .ToDictionary(t => t.Name, t => t.Name);

                //dictionary.Add("OnBoardingPages", "OnBoardingPages");

                return dictionary;
            }
        }
    }
}
