namespace WellItCouldWork.SyntaxHelpers
{
    public interface IGiveAFluentFeelToYourSyntaxFor<T> { } //Marker interface, generic type required for inference when used

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