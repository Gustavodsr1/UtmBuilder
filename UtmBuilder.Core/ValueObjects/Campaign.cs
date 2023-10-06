using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtmBuilder.Core.ValueObjects
{
    internal class Campaign : ValueObject
    {
        public Campaign(string source, string medium, string name, string? id = null, string? term = null, string? content = null)
        {
            Source = source;
            Medium = medium;    
            Name = name;
            Id = id;    
            Term = term;    
            Content = content;  
        }

        public string? Id { get; }
        public string Source { get; }
        public string Medium { get; }
        public string Name { get; }
        public string? Term { get; }
        public string? Content { get; }
    }
}
