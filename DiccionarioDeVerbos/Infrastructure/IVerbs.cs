using DiccionarioDeVerbos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiccionarioDeVerbos.Infrastructure
{
    public interface IVerbs
    {
        Task<string> SearchVerb(VerbDto data);
    }
}
