using System;
using System.Collections.Generic;

namespace AutofacExample
{
    public class ArgumentsParser
    {
        private string[] arguments;
        private string requestedOutputMode = string.Empty;

        // default output mode when no args specified
        private List<OutputModes> outputModes = new List<OutputModes>() { OutputModes.Console };

        public ArgumentsParser(string[] args)
        {
            arguments = args;
        }

        public Config GetConfig()
        {
            SanityCheckArgs();

            return new Config(outputModes);
        }

        private void SanityCheckArgs()
        {
            // no-args to check
            if (arguments.Length == 0)
            {
                return;
            }

            // too many args
            if (arguments.Length > 3)
            {
                throw new ArgumentException(
                    "Too many arguments were specified, expected 'console','popup','file', or 'all'");
            }

            SetupOutputModes();
        }

        private void SetupOutputModes()
        {
            outputModes = new List<OutputModes>();

            // see if each requested output-mode exists in our struct
            foreach (var outputModeRequested in arguments)
            {
                try
                {
                    outputModes.Add((OutputModes)Enum.Parse(typeof(OutputModes), outputModeRequested, true));
                }
                catch
                {
                    throw new ArgumentException(string.Format(
                     "Illegal output mode '{0}' requested, expected 'console','popup','file', or 'all'",
                     outputModeRequested));
                }
            }

            // handles odd input like "console all"
            if (outputModes.Contains(OutputModes.All))
            {
                outputModes = new List<OutputModes> { OutputModes.All };
            }
        }
    }
}
