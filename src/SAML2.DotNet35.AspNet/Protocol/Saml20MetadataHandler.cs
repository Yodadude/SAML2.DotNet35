using System;
using System.Security.Cryptography.X509Certificates;
//using System.Security.Cryptography.Xml;
using System.Text;
using System.Web;
using SAML2.DotNet35.Config;
using SAML2.DotNet35.AspNet;
using SAML2.DotNet35.Utils;

namespace SAML2.DotNet35.Protocol
{
    /// <summary>
    /// The handler that exposes a metadata endpoint to the other parties of the federation.
    /// The handler accepts the following GET parameters :
    /// - encoding : Delivers the Metadata document in the specified encoding. Example: encoding=iso-8859-1 . If the parameter is omitted, the encoding utf-8 is used.
    /// - sign : A boolean parameter specifying whether to sign the metadata document. Example: sign=false. If the parameter is omitted, the document is signed.
    /// </summary>
    public class Saml20MetadataHandler : AbstractEndpointHandler
    {
        /// <summary>
        /// Gets a value indicating whether this instance is reusable.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is reusable; otherwise, <c>false</c>.
        /// </value>
        public new bool IsReusable
        {
            get { return false; }
        }
        
        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public override void ProcessRequest(HttpContext context)
        {
            var encoding = context.Request.QueryString["encoding"];
            try
            {
                if (!string.IsNullOrEmpty(encoding))
                {
                    context.Response.ContentEncoding = Encoding.GetEncoding(encoding);
                }
            }
            catch (ArgumentException ex)
            {
                Logger.ErrorFormat(ErrorMessages.UnknownEncoding, encoding);
                throw new ArgumentException(string.Format(ErrorMessages.UnknownEncoding, encoding), ex);
            }

            var sign = true;
            var param = context.Request.QueryString["sign"];                
            if (!string.IsNullOrEmpty(param))
            {
                if (!bool.TryParse(param, out sign))
                {
                    throw new ArgumentException(ErrorMessages.MetadataSignQueryParameterInvalid);
                }
            }
                        
            context.Response.ContentType = Saml20Constants.MetadataMimetype;
            context.Response.AddHeader("Content-Disposition", "attachment; filename=\"metadata.xml\"");

            var metautil = new MetadataUtils(ConfigurationFactory.Instance.Configuration, Logger);
            context.Response.Write(metautil.CreateMetadataDocument(context.Response.ContentEncoding, sign));
            
            context.Response.End();            
        }

    }
}
