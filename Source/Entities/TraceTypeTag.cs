using Ada.Framework.Development.Log4Me.Config.Entities;
using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Writers.TraceWrite.Entities
{
    [XmlType("TraceType")]
    public class TraceTypeTag : TypeTag
    {
        /// <summary>
        /// Permite obtener o establecer el nivel de traceo del registro.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlIgnore]
        public NivelTrace NivelTrace
        {
            get
            {
                return NivelTrace.ObtenerEnumeracion(_NivelTrace) as NivelTrace;
            }
            set
            {
                _NivelTrace = value == null ? value.Codigo : null;
            }
        }

        /// <summary>
        /// Permite obtener o establecer el nivel de traceo del registro.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute(AttributeName = "TraceLevel")]
        public string _NivelTrace { get; set; }
    }
}
