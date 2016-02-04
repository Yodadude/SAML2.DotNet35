using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SAML2.DotNet35.Schema.Metadata
{
    [Serializable]
    [XmlType(TypeName = "ApplicationServiceType", Namespace = Saml20Constants.Adfs)]
    [XmlRoot(ElementName, Namespace = Saml20Constants.Adfs, IsNullable = false)]
    public class AdfsApplicationServiceTypeRoleDescriptor : RoleDescriptor
    {
    }
}
