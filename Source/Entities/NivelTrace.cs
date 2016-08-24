using Ada.Framework.Core;

namespace Ada.Framework.Development.Log4Me.Writers.TraceWrite.Entities
{
    public sealed class NivelTrace : Enumeracion<string>
    {
        private NivelTrace(string codigo) : base(codigo) { }

        public static readonly NivelTrace DEBUG = new NivelTrace("DEBUG");
        public static readonly NivelTrace INFO = new NivelTrace("INFO");
        public static readonly NivelTrace ERROR = new NivelTrace("ERROR");
        public static readonly NivelTrace WARN = new NivelTrace("WARN");
        public static readonly NivelTrace FAIL = new NivelTrace("FAIL");
    }
}
