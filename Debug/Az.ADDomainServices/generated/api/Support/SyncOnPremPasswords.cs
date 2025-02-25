// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support
{

    /// <summary>A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.</summary>
    public partial struct SyncOnPremPasswords :
        System.IEquatable<SyncOnPremPasswords>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords Disabled = @"Disabled";

        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords Enabled = @"Enabled";

        /// <summary>the value for an instance of the <see cref="SyncOnPremPasswords" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to SyncOnPremPasswords</summary>
        /// <param name="value">the value to convert to an instance of <see cref="SyncOnPremPasswords" />.</param>
        internal static object CreateFrom(object value)
        {
            return new SyncOnPremPasswords(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type SyncOnPremPasswords</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type SyncOnPremPasswords (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is SyncOnPremPasswords && Equals((SyncOnPremPasswords)obj);
        }

        /// <summary>Returns hashCode for enum SyncOnPremPasswords</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="SyncOnPremPasswords" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private SyncOnPremPasswords(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for SyncOnPremPasswords</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to SyncOnPremPasswords</summary>
        /// <param name="value">the value to convert to an instance of <see cref="SyncOnPremPasswords" />.</param>

        public static implicit operator SyncOnPremPasswords(string value)
        {
            return new SyncOnPremPasswords(value);
        }

        /// <summary>Implicit operator to convert SyncOnPremPasswords to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="SyncOnPremPasswords" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum SyncOnPremPasswords</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords e1, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum SyncOnPremPasswords</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords e1, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords e2)
        {
            return e2.Equals(e1);
        }
    }
}