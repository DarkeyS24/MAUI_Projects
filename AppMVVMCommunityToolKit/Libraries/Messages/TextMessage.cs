using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace AppMVVMCommunityToolKit.Libraries.Messages
{
    public class TextMessage : ValueChangedMessage<string>
    {
        public TextMessage(string value) : base(value)
        {

        }
    }
}
