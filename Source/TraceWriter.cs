using Ada.Framework.Development.Log4Me.Entities;
using Ada.Framework.Development.Log4Me.Writers.TraceWrite.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Writers.TraceWrite
{
    [Serializable]
    public class TraceWriter : ALogWriter
    {
        [XmlArray("TraceTypes")]
        [XmlArrayItem("TraceType")]
        public List<TraceTypeTag> NivelesSeguimiento { get; set; }

        public override void AgregarParametros()
        {
            Trace.WriteLine(FormatoSalida);
            Trace.WriteLine(SeparadorSalida);
        }

        public override void Inicializar() { }

        protected override void Agregar(RegistroInLineTO registro)
        {
            string salida = Formatear(registro);

            NivelTrace nivel = null;
            TraceTypeTag tipo = null;

            if (NivelesSeguimiento != null)
            {
                if (registro.Tipo == Tipo.Mensaje)
                {
                    tipo = NivelesSeguimiento.FirstOrDefault(c => c.Nombre == Tipo.Mensaje && c.Nivel != null && c.Nivel == registro.Nivel);

                    if (tipo == null)
                    {
                        tipo = NivelesSeguimiento.FirstOrDefault(c => c.Nombre == Tipo.Mensaje && c._Nivel == "*");
                    }
                }

                if (tipo == null)
                {
                    tipo = NivelesSeguimiento.FirstOrDefault(c => c._Nombre.Equals("*", StringComparison.InvariantCultureIgnoreCase));
                }

            }

            if (tipo != null)
            {
                nivel = tipo.NivelTrace;
            }
            
            if (nivel == NivelTrace.DEBUG) Trace.WriteLine(salida);
            if (nivel == NivelTrace.INFO) Trace.TraceInformation(salida);
            if (nivel == NivelTrace.ERROR) Trace.TraceError(salida);
            if (nivel == NivelTrace.WARN) Trace.TraceWarning(salida);
            if (nivel == NivelTrace.FAIL) Trace.Fail(salida);
        }
    }
}
