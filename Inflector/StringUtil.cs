using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflectionServices
{
    public static class StringUtil
    {
        private static Inflector inflect = new Inflector();
        
        public static string Pluralize(string word)
        {
            return inflect.Pluralize(word);
        }

        public static string Pluralize(string word, int count)
        {
            return count > 1 ? inflect.Pluralize(word) : word;
        }
    }
}
