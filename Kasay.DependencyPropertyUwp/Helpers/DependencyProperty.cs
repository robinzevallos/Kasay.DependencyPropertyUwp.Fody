namespace Kasay.DependencyPropertyUwp.Helpers
{
    using System;
    using Windows.UI.Xaml;

    public class LocalDependencyProperty
    {
        public static DependencyProperty Register(String name, Type propertyType, Type ownerType)
        {
            return DependencyProperty.Register(name, propertyType, ownerType, null);
        }
    }
}
