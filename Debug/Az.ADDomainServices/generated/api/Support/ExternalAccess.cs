// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support
{

    /// <summary>
    /// A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.
    /// </summary>
    public partial struct ExternalAccess :
        System.IEquatable<ExternalAccess>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess Disabled = @"Disabled";

        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess Enabled = @"Enabled";

        /// <summary>the value for an instance of the <see cref="ExternalAccess" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ExternalAccess</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ExternalAccess" />.</param>
        internal static object CreateFrom(object value)
        {
            return new ExternalAccess(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ExternalAccess</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ExternalAccess (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ExternalAccess && Equals((ExternalAccess)obj);
        }

        /// <summary>Creates an instance of the <see cref="ExternalAccess" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ExternalAccess(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns hashCode for enum ExternalAccess</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ExternalAccess</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ExternalAccess</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ExternalAccess" />.</param>

        public static implicit operator ExternalAccess(string value)
        {
            return new ExternalAccess(value);
        }

        /// <summary>Implicit operator to convert ExternalAccess to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ExternalAccess" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ExternalAccess</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess e1, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ExternalAccess</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess e1, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess e2)
        {
            return e2.Equals(e1);
        }
    }
}