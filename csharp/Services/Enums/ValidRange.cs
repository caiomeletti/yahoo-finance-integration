namespace Services.Enums
{
    public class ValidRange
    {
        private ValidRange(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static ValidRange D1 { get { return new ValidRange("1d"); } }
        public static ValidRange D5 { get { return new ValidRange("5d"); } }
        public static ValidRange M1 { get { return new ValidRange("1mo"); } }
        public static ValidRange M3 { get { return new ValidRange("3mo"); } }
        public static ValidRange M6 { get { return new ValidRange("6mo"); } }
        public static ValidRange Y1 { get { return new ValidRange("1y"); } }
        public static ValidRange Y2 { get { return new ValidRange("2y"); } }
        public static ValidRange Y5 { get { return new ValidRange("5y"); } }
        public static ValidRange Y10 { get { return new ValidRange("10y"); } }
        public static ValidRange Yesterday { get { return new ValidRange("ytd"); } }
        public static ValidRange Max { get { return new ValidRange("max"); } }

        public override string ToString()
        {
            return Value;
        }
    }
}
