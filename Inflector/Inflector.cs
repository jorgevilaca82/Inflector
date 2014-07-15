using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace InflectionServices
{
    public class InflectionRules : Dictionary<string, string> { }

    public class Inflector
    {
        public static InflectionRules SingularRules { get; set; }
        private InflectionRules PluralRules { get; set; }
        private InflectionRules IrregularRules { get; set; }
        private IList<string> UncountableWords { get; set; }

        public Inflector()
        {
            SingularRules = new InflectionRules()
            {
                {"([^ê])s$", "$1"},
                {"^(á|gá|paí)s$", "$1s"},
                {"(r|z)es$", "$1"},
                {"([^p])ais$", "$1al"},
                {"eis$", "el"},
                {"ois$", "ol"},
                {"uis$", "ul"},
                {"(r|t|f|v)is$", "$1il"},
                {"ns$", "m"},
                {"sses$", "sse"},
                {"^(.*[^s]s)es$", "$1"},
                {"ães$", "ão"},
                {"aes$", "ao"},
                {"ãos$", "ão"},
                {"aos$", "ao"},
                {"ões$", "ão"},
                {"oes$", "ao"},
                {"(japon|escoc|ingl|dinamarqu|fregu|portugu)eses$", "$1ês"},
                {"^(g|)ases$", "$1ás"}
            };

            PluralRules = new InflectionRules()
            {
                {"$", "s"},
                {"(s)$", "$1"},
                {"^(paí)s$", "$1ses"},
                {"(z|r)$", "$1es"},
                {"al$", "ais"},
                {"el$", "eis"},
                {"ol$", "ois"},
                {"ul$", "uis"},
                {"([^aeou])il$", "$1is"},
                {"m$", "ns"},
                {"^(japon|escoc|ingl|dinamarqu|fregu|portugu)ês$", "$1eses"},
                {"^(|g)ás$", "$1ases"},
                {"ão$", "ões"},
                {"^(irm|m)ão$", "$1ãos"},
                {"^(alem|c|p)ão$", "$1ães"},
                {"ao$", "oes"},
                {"^(irm|m)ao$", "$1aos"},
                {"^(alem|c|p)ao$", "$1aes"},
            };

            IrregularRules = new InflectionRules()
            {
                {"país", "países"}
            };

            UncountableWords = new string[] { "tórax", "tênis", "ônibus", "lápis", "fênix" };
        }

        public string ApplyInflection(string word, InflectionRules rules)
        {
            IEnumerable<string> ruleKeys = rules.Keys.Reverse();
            foreach (string rule in ruleKeys)
            {
                var _pattern = rule;
                if (Regex.IsMatch(word, _pattern))
                {
                    return new Regex(_pattern).Replace(word, rules[rule]);
                }
            }
            return null;
        }

        public bool isUncountable(string word)
        {
            return UncountableWords.Contains(word.ToLower());
        }

        public string TryUncountableOrIrregular(string word)
        {
            string _s = null;
            if (isUncountable(word))
                return word;

            _s = ApplyInflection(word, IrregularRules);
            if (!String.IsNullOrEmpty(_s))
                return _s;
            return null;
        }

        public string Pluralize(string word)
        {
            string _s = TryUncountableOrIrregular(word);
            if (!String.IsNullOrEmpty(_s))
                return _s;

            _s = ApplyInflection(word, PluralRules);
            if (!String.IsNullOrEmpty(_s))
                return _s;

            return word;
        }

        public string Singularize(string word)
        {
            string _s = TryUncountableOrIrregular(word);
            if (!String.IsNullOrEmpty(_s))
                return _s;

            _s = ApplyInflection(word, SingularRules);
            if (!String.IsNullOrEmpty(_s))
                return _s;

            return word;
        }
    
    }

}
