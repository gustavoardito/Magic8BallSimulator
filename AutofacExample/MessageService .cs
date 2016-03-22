using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacExample
{
    public class MessageService
    {

        public MessageService()
        {
            SetupMessages();
        }

        private List<string> messages = new List<string>();

        private void SetupMessages()
        {
            messages = new List<string>
                           {
                               "Signs point to yes.",
                               "Yes."
                           };
        }

        public string GetMessage()
        {
            Random random = new Random();
            int index = random.Next(0, messages.Count - 1);

            return messages[index];
        }
    }
}
