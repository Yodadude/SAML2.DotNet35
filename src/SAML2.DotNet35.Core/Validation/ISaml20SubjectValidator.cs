using SAML2.DotNet35.Schema.Core;

namespace SAML2.DotNet35.Validation
{
    /// <summary>
    /// SAML2 Subject Validator interface.
    /// </summary>
    public interface ISaml20SubjectValidator
    {
        /// <summary>
        /// Validates the subject.
        /// </summary>
        /// <param name="subject">The subject.</param>
        void ValidateSubject(Subject subject);
    }
}
