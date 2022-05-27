// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support
{

    /// <summary>A flag to determine whether or not Secure LDAP is enabled or disabled.</summary>
    public partial struct Ldaps :
        System.IEquatable<Ldaps>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps Disabled = @"Disabled";

        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps Enabled = @"Enabled";

        /// <summary>the value for an instance of the <see cref="Ldaps" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to Ldaps</summary>
        /// <param name="value">the value to convert to an instance of <see cref="Ldaps" />.</param>
        internal static object CreateFrom(object value)
        {
            return new Ldaps(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type Ldaps</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type Ldaps (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is Ldaps && Equals((Ldaps)obj);
        }

        /// <summary>Returns hashCode for enum Ldaps</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="Ldaps" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private Ldaps(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for Ldaps</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to Ldaps</summary>
        /// <param name="value">the value to convert to an instance of <see cref="Ldaps" />.</param>

        public static implicit operator Ldaps(string value)
        {
            return new Ldaps(value);
        }

        /// <summary>Implicit operator to convert Ldaps to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="Ldaps" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum Ldaps</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps e1, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum Ldaps</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps e1, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps e2)
        {
            return e2.Equals(e1);
        }
    }
}