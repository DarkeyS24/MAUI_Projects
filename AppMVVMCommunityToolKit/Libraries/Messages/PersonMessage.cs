using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMVVMCommunityToolKit.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace AppMVVMCommunityToolKit.Libraries.Messages
{
    class PersonMessage : ValueChangedMessage<Person>
    {
        public PersonMessage(Person value) : base(value)
        {
        }
    }
}
