namespace EnumsPackage
{
    public class EnumClass
    {
        public enum Products
        {
            SAUCE_LABS_BACKPACK = 1,
            SAUCE_LABS_BIKE_LIGHT = 2,
            SAUCE_LABS_BOLTS_T_SHIRT = 3,
            SAUCE_LABS_FLEECE_JACKET = 4,
            SAUCE_LABS_ONESIE = 5,
            TEST_ALL_THE_THINGS_T_SHIRT_RED = 6,
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private String name;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private void Products_SauceDemoEnums(String name)
        {
            this.name = name;
        }

        public String GetResourcesName()
        {
            return name;
        }
    }
}