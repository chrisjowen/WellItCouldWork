namespace WellItCouldWork.SyntaxHelpers
{
// ReSharper disable UnusedTypeParameter -> Type used for inferance
    public interface IGiveAFluentFeelToYourSyntaxFor<T>
// ReSharper restore UnusedTypeParameter
    {
    }

    public static class IGiveAFluentFeelToYourSyntaxExt
    {
        public static T And<T>(this IGiveAFluentFeelToYourSyntaxFor<T> fluentFeelToYourSyntaxForType)
        {
            return (T)fluentFeelToYourSyntaxForType;
        }

        public static T Given<T>(this IGiveAFluentFeelToYourSyntaxFor<T> fluentFeelToYourSyntaxForType)
        {
            return (T)fluentFeelToYourSyntaxForType;
        }

        public static T When<T>(this IGiveAFluentFeelToYourSyntaxFor<T> fluentFeelToYourSyntaxForType)
        {
            return (T)fluentFeelToYourSyntaxForType;
        }

        public static T Then<T>(this IGiveAFluentFeelToYourSyntaxFor<T> fluentFeelToYourSyntaxForType)
        {
            return (T)fluentFeelToYourSyntaxForType;
        }

        public static T With<T>(this IGiveAFluentFeelToYourSyntaxFor<T> fluentFeelToYourSyntaxForType)
        {
            return (T)fluentFeelToYourSyntaxForType;
        }        
        
        public static T A<T>(this IGiveAFluentFeelToYourSyntaxFor<T> fluentFeelToYourSyntaxForType)
        {
            return (T)fluentFeelToYourSyntaxForType;
        }
    }
}