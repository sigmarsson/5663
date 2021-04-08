using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.History.UI.Entity
{
    public record MicrosoftAccount
    {
        public string Email { get; set; }

        public string AccountType { get; set; }

        public string Picture { get; set; }
    }
}
