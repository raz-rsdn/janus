﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rsdn.Janus {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ConfigResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ConfigResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Rsdn.Janus.Config.ConfigResources", typeof(ConfigResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Direct connection.
        /// </summary>
        internal static string ProxyDirectConnection {
            get {
                return ResourceManager.GetString("ProxyDirectConnection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Low.
        /// </summary>
        internal static string SyncThreadPriorityLow {
            get {
                return ResourceManager.GetString("SyncThreadPriorityLow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Normal.
        /// </summary>
        internal static string SyncThreadPriorityNormal {
            get {
                return ResourceManager.GetString("SyncThreadPriorityNormal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Direct Connection.
        /// </summary>
        internal static string UseProxyType_NoUse {
            get {
                return ResourceManager.GetString("UseProxyType_NoUse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use custom proxy server.
        /// </summary>
        internal static string UseProxyType_UseCustomSettings {
            get {
                return ResourceManager.GetString("UseProxyType_UseCustomSettings", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use settings from IE.
        /// </summary>
        internal static string UseProxyType_UseIESettings {
            get {
                return ResourceManager.GetString("UseProxyType_UseIESettings", resourceCulture);
            }
        }
    }
}