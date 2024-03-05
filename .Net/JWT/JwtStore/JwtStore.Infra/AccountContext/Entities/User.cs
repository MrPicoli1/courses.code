using JwtStore.Infra.AccountContext.ValueObjects;
using JwtStore.Infra.SharedContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtStore.Infra.AccountContext.Entities
{
    public class User :Entity
    {
        public string Name { get; set; }
        public Email Email { get; private set; }

    }
}
