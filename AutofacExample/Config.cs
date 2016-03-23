using System.Collections.Generic;

namespace AutofacExample
{
    public enum OutputModes
    {
        Console,

        Popup,

        File,

        All
    }

    // holds our configuration, this class will be easy to expand later on
    // if we need to
    public class Config
    {
        public Config(List<OutputModes> outputPreferences)
        {
            OutputModes = outputPreferences;
        }

        public List<OutputModes> OutputModes { get; private set; }
    }
}
